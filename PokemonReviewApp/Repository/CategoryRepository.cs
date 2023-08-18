﻿using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : IcategoryRepository
    {
        private ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public bool CategoriesExists(int id)
        {
          return _context.Categories.Any(c => c.Id == id);  
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.
                Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();  
        }

        public bool save()
        {
            var saved =_context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);

            return save();
        }
    }
}
