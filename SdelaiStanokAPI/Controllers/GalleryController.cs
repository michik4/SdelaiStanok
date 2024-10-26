using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SdelaiStanokAPI.data;
using SdelaiStanokAPI.models;

namespace SdelaiStanokAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GalleryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GalleryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GalleryItem>>> GetGalleryItems()
        {
            return await _context.GalleryItems
                .Include(item => item.Description)
                .Include(item => item.Tags)
                .Include(item => item.Images)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GalleryItem>> GetGalleryItem(int id)
        {
            var galleryItem = await _context.GalleryItems
                .Include(item => item.Description)
                .Include(item => item.Tags)
                .Include(item => item.Images)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (galleryItem == null)
            {
                return NotFound();
            }

            return galleryItem;
        }

        [HttpPost]
        public async Task<ActionResult<GalleryItem>> PostGalleryItem(GalleryItem galleryItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            if (galleryItem.Description != null && !string.IsNullOrEmpty(galleryItem.Description.Text))
            {
                _context.Descriptions.Add(galleryItem.Description);

            }

            try
            {
                // Отключаем автоматическое обнаружение изменений
                _context.ChangeTracker.AutoDetectChangesEnabled = false;

                _context.GalleryItems.Add(galleryItem);

                await _context.SaveChangesAsync(); // Сохраняем GalleryItem и Description

                if (galleryItem.Images != null)
                {
                    foreach (var image in galleryItem.Images)
                    {
                        image.GalleryItemId = galleryItem.Id;

                        image.GalleryItem = galleryItem; // Устанавливаем navigation property

                        _context.GalleryImages.Add(image);


                    }

                    await _context.SaveChangesAsync();

                }

                if (galleryItem.Tags != null)
                {

                    foreach (var tag in galleryItem.Tags)
                    {

                        Tag? existingTag = null;
                        if (!string.IsNullOrEmpty(tag.Name))
                        {
                            existingTag = await _context.Tags
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(t => t.Name == tag.Name);


                        }
                        if (existingTag != null)
                        {
                            galleryItem.Tags.Remove(tag);

                            galleryItem.Tags.Add(existingTag);

                        }
                        else if (!string.IsNullOrEmpty(tag.Name))
                        {

                            _context.Tags.Add(tag);
                            tag.GalleryItems = new List<GalleryItem> { galleryItem };


                        }


                    }

                }
                await _context.SaveChangesAsync();

                // Включаем обратно автоматическое обнаружение изменений
                _context.ChangeTracker.AutoDetectChangesEnabled = true;

                return CreatedAtAction(nameof(GetGalleryItem), new { id = galleryItem.Id }, galleryItem);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalleryItem(int id, GalleryItem galleryItem)
        {
            if (id != galleryItem.Id)
            {
                return BadRequest();
            }


            _context.Entry(galleryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalleryItem(int id)
        {
            var galleryItem = await _context.GalleryItems.FindAsync(id);
            if (galleryItem == null)
            {
                return NotFound();
            }

            _context.GalleryItems.Remove(galleryItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GalleryItemExists(int id)
        {
            return _context.GalleryItems.Any(e => e.Id == id);
        }
    }
}