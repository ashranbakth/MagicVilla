using Microsoft.AspNetCore.Mvc;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Data;
using Microsoft.AspNetCore.JsonPatch;
using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Controllers
{
	//[Route("api/[controller]")] // FOR REFERENCE
	[Route("api/VillaAPI")]
	[ApiController]
	public class VillaAPIController: ControllerBase
	{
		private readonly ApplicationDbContext _db;

		public VillaAPIController(ApplicationDbContext db)
		{
			_db = db;
		}


		[HttpGet]
		public ActionResult<IEnumerable<VillaDTO>> GetVillas()
		{
			return Ok(_db.Villas.ToList());
		}

        [HttpGet("{id:int}", Name = "GetVilla")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		//[ProducesResponseType(200, Type=typeof(VillaDTO))] // FOR REFERENCE
        public ActionResult<VillaDTO> GetVilla(int id)
        {
			if(id == 0)
			{
				return BadRequest();
			}
			var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
			if(villa == null)
			{
				
				return NotFound();
			}

            return Ok(villa);
        }

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody]VillaDTO villaDTO)
		{
			if(_db.Villas.FirstOrDefault(x => x.Name.ToLower() == villaDTO.Name.ToLower()) != null)
			{
				ModelState.AddModelError("CustomError", "Villa already Exists!");
				return BadRequest(ModelState);
			}
			if(villaDTO == null)
			{
				return BadRequest(villaDTO);
			}
			if(villaDTO.Id > 0)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			Villa model = new Villa()
			{
				Amenity = villaDTO.Amenity,
				Details = villaDTO.Details,
				Id = villaDTO.Id,
				ImageUrl = villaDTO.ImageUrl,
				Name = villaDTO.Name,
				Occupancy = villaDTO.Occupancy,
				Rate = villaDTO.Rate,
				Sqft = villaDTO.Sqft
			};
			_db.Villas.Add(model);
			_db.SaveChanges();
			
			return CreatedAtRoute("GetVilla", new {id = villaDTO.Id} ,villaDTO);

		}


		[HttpDelete("{id:int}", Name = "DeleteVilla")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult DeleteVilla(int id)
		{
			if(id == 0)
			{
				return BadRequest();
			}
            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
			if(villa == null)
			{
				return NotFound();
			}
			_db.Villas.Remove(villa);
			_db.SaveChanges();
            return NoContent();
		}


		[HttpPut("{id:int}", Name = "UpdateVilla")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
		{
			if(villaDTO == null || id != villaDTO.Id)
			{
				return BadRequest();
			}
			//         var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
			//villa.Name = villaDTO.Name;
			//villa.Occupancy = villaDTO.Occupancy;
			//villa.Sqft = villaDTO.Sqft;
			Villa model = new Villa()
			{
				Amenity = villaDTO.Amenity,
				Details = villaDTO.Details,
				Id = villaDTO.Id,
				ImageUrl = villaDTO.ImageUrl,
				Name = villaDTO.Name,
				Occupancy = villaDTO.Occupancy,
				Rate = villaDTO.Rate,
				Sqft = villaDTO.Sqft
			};
			_db.Villas.Update(model);
			_db.SaveChanges();

			return NoContent();
        }

		[HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
		{
			if(patchDTO == null || id == 0)
			{
				return BadRequest();
			}
			var villa = _db.Villas.AsNoTracking().FirstOrDefault(u => u.Id == id);

			VillaDTO villaDTO = new()
			{
				Amenity = villa.Amenity,
				Details = villa.Details,
				Id = villa.Id,
				ImageUrl = villa.ImageUrl,
				Name = villa.Name,
				Occupancy = villa.Occupancy,
				Rate = villa.Rate,
				Sqft = villa.Sqft
			};
			if(villa == null)
			{
				return NotFound();
			}
			patchDTO.ApplyTo(villaDTO, ModelState);
			Villa model = new Villa()
			{
				Amenity = villaDTO.Amenity,
				Details = villaDTO.Details,
				Id = villaDTO.Id,
				ImageUrl = villaDTO.ImageUrl,
				Name = villaDTO.Name,
				Occupancy = villaDTO.Occupancy,
				Rate = villaDTO.Rate,
				Sqft = villaDTO.Sqft
			};
			_db.Villas.Update(model);
			_db.SaveChanges();
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return NoContent();

        }

    }
}

