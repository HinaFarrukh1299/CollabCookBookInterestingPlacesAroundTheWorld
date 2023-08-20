using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Diagnostics;
using CollabCookBookInterestingPlacesAroundTheWorld.Migrations;
using CollabCookBookInterestingPlacesAroundTheWorld.Models;

namespace CollabCookBookInterestingPlacesAroundTheWorld.Controllers
{
    public class RecipesDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RecipesData/ListRecipes
        [HttpGet]
        public IEnumerable<RecipeDto> ListRecipes()
        {
            List<Recipe> Recipes = db.Recipes.ToList();
            List<RecipeDto> RecipeDtos = new List<RecipeDto>();
            Recipes.ForEach(a => RecipeDtos.Add(new RecipeDto()
            {

                RecipeId = a.RecipeId,
                RecipeTitle = a.RecipeTitle,
                Instructions = a.Instructions,
                CookTime = a.CookTime,
                ServingSize = a.ServingSize,
                
            }


                
            
    ));
            return RecipeDtos;



    }

    // GET: api/RecipesData/FindRecipe/5
    [ResponseType(typeof(Recipe))]
        [HttpGet]
        public IHttpActionResult FindRecipe(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            RecipeDto RecipeDto = new RecipeDto()
            {
                RecipeId = recipe.RecipeId,
                RecipeTitle = recipe.RecipeTitle,
                Instructions = recipe.Instructions,
                CookTime = recipe.CookTime,
                ServingSize = recipe.ServingSize,


            };
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(RecipeDto);
        }

        // POST: api/UpdateRecipes/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateRecipe(int id, Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipe.RecipeId)
            {
                return BadRequest();
            }

            db.Entry(recipe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RecipesData/AddRecipe
        [ResponseType(typeof(Recipe))]
        [HttpPost]
        public IHttpActionResult AddRecipe(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recipes.Add(recipe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recipe.RecipeId }, recipe);
        }

        // POST: api/RecipesData/DeleteRecipe/5
        [ResponseType(typeof(Recipe))]
        [HttpPost]
        public IHttpActionResult DeleteRecipe(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }

            db.Recipes.Remove(recipe);
            db.SaveChanges();

            return Ok(recipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeExists(int id)
        {
            return db.Recipes.Count(e => e.RecipeId == id) > 0;
        }
    }
}