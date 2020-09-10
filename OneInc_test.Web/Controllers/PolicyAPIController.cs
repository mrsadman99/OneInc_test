using OneInc_test.BusinessLogic.Services;
using OneInc_test.Core.Entities;
using OneInc_test.Data.Repositories;
using OneInc_test.Web.Mapping;
using OneInc_test.Web.Models;
using OneInc_test.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Web.Http;
using static OneInc_test.Web.Mapping.ConfigurationBuilder;

namespace OneInc_test.Web.Controllers
{
    public class PolicyAPIController : ApiController
    {
        private readonly PolicyService _policyService;

        public PolicyAPIController()
        {
            var context = new AppDbContext();
            var policyRep = new PolicyRepository(context);
            _policyService = new PolicyService(policyRep, context);
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var policy = await _policyService.GetByIdAsync(id);
            if (policy == null)
            {
                return NotFound();
            }

            return Ok(MapperBuilder.Build(ConfigType.In)
                        .Map<PolicyDtoCreated>(policy));
        }
        public async Task<IHttpActionResult> GetCollection()
        {
            var selectedPolicies = await _policyService
                    .GetListAsync();
            if (selectedPolicies == null)
                return BadRequest();
            return Ok(MapperBuilder.Build(ConfigType.In)
                        .Map<List<PolicyDtoCreated>>(selectedPolicies));
        }

        [HttpPost,Route("api/PolicyAPI/filtered")]
        public async Task<IHttpActionResult> GetByOption(
            Filter filter)
        {
            if (filter != null)
            {
                if (filter.updateDate != null)
                    _policyService
                        .GetUpdatedAfterDate(filter.updateDate.Value);
                if (filter.name != null)
                    _policyService
                        .GetByName(filter.name);
                if (filter.surname != null)
                    _policyService
                        .GetBySurname(filter.surname);
                if (filter.state != null)
                    _policyService
                        .GetByState(filter.state.Value);
                if (filter.objectName != null)
                    _policyService
                        .GetByObjectName(filter.objectName);
                var selectedPolicies = await _policyService
                    .GetListAsync();

                if (selectedPolicies == null)
                    return BadRequest();
                
                if (filter.nameSelected)
                    return Ok(MapperBuilder.Build(ConfigType.Owner)
                        .Map<List<Owner>>(selectedPolicies));
                else
                    return Ok(MapperBuilder.Build(ConfigType.In)
                        .Map<List<PolicyDtoCreated>>(selectedPolicies));
            }
            return BadRequest();
        }
        
        public async Task<IHttpActionResult> PostPolicy(PolicyDtoCreated editPolicy)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var editEntity = MapperBuilder.Build(ConfigType.OutModified)
                                .Map<Policy>(editPolicy);
                await _policyService.UpdateAsync(editEntity);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        public async Task<IHttpActionResult> PutNewPolicy(PolicyDtoCreate newPolicy)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var newEntity = MapperBuilder.Build(ConfigType.Out)
                                .Map<Policy>(newPolicy);
                var num=await _policyService.AddAsync(newEntity);
                
                return Ok(newEntity.PolicyNumber);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        public async Task<IHttpActionResult> DeletePolicy(int id)
        {
            var deletedPolicy=await _policyService.GetByIdAsync(id);
            if (deletedPolicy == null)
                return NotFound();
            try
            {
                await _policyService.DeleteAsync(deletedPolicy);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            _policyService.Dispose();
            base.Dispose(disposing);
        }

    }
}