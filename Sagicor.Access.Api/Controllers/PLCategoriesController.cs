using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Sagicor.Access.Application.Features.PLCategory.Commands.CreatePLCategory;
using Sagicor.Access.Application.Features.PLCategory.Commands.DeletePLCategory;
using Sagicor.Access.Application.Features.PLCategory.Commands.UpdatePLCategory;
using Sagicor.Access.Application.Features.PLCategory.Queries.GetAllPLCategories;
using Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetails;
using Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetailsByCode;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sagicor.Access.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PLCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        //// GET: api/<PLCategoriesController>
        public PLCategoriesController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<List<PLCategoryDto>> Get()
        {
            var pLCategories = await _mediator.Send(new GetPLCategoriesQuery());
            return pLCategories;
        }
        // GET api/<PLCategoriesController>/1DC2265E-8645-486D-9B40-01186153E53D
        [HttpGet("id/{id}", Name = "GetById")]
        public async Task<ActionResult<PLCategoryDetailsDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetPLCategoryDetailsQuery(id));
            //return Ok(new { success = true, data = plCategory });
            return Ok(response);
        }
        // GET api/<PLCategoriesController>/52484
        [HttpGet("code/{code}", Name = "GetByCode")]
        public async Task<ActionResult<PLCategoryDetailsByCodeDto>> Get(string code)
        {
            var response = await _mediator.Send(new GetPLCategoryDetailsByCodeQuery(code));
            return Ok(response);
        }
        // POST api/<PLCategoriesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreatePLCategoryCommand createPLCategory)
        {
            var response = await _mediator.Send(createPLCategory);
            return CreatedAtAction(nameof(Get), new { id = response }, new { id = response });
        }

        // PUT api/<PLCategoriesController>/5
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdatePLCategoryCommand updatePLCategory)
        {
            await _mediator.Send(updatePLCategory);
            return NoContent();
        }

        // DELETE api/<PLCategoriesController>/5
        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeletePLCategoryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
