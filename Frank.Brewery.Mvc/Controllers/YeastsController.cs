using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Frank.Brewery.DataContexts;
using Frank.Brewery.Entities;
using Frank.Brewery.Repositories;

namespace Frank.Brewery.Mvc.Controllers
{
    public class YeastsController : Controller
    {
        private readonly IYeastRepository _yeastRepository;

        public YeastsController(IYeastRepository yeastRepository)
        {
            _yeastRepository = yeastRepository;
        }

        // GET: Yeasts
        public async Task<IActionResult> Index()
        {
            return View(await _yeastRepository.GetAll());
        }

        // GET: Yeasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeasts = await _yeastRepository.GetAll();
            var yeast = yeasts.FirstOrDefault(m => m.Id == id);
            if (yeast == null)
            {
                return NotFound();
            }

            return View(yeast);
        }

        // GET: Yeasts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yeasts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Link,Price,Count,BrewCategory,AlcoholTolerance,Flocculation")] Yeast yeast)
        {
            if (ModelState.IsValid)
            {
                await _yeastRepository.Add(yeast);
                return RedirectToAction(nameof(Index));
            }
            return View(yeast);
        }

        // GET: Yeasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeasts = await _yeastRepository.GetAll();
            var yeast = yeasts.FirstOrDefault(m => m.Id == id);
            if (yeast == null)
            {
                return NotFound();
            }
            return View(yeast);
        }

        // POST: Yeasts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Link,Price,Count,BrewCategory,AlcoholTolerance,Flocculation")] Yeast yeast)
        {
            if (id != yeast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _yeastRepository.Update(yeast);
                return RedirectToAction(nameof(Index));
            }
            return View(yeast);
        }

        // GET: Yeasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeast = await _yeastRepository.Remove(id.Value);
            if (!yeast)
            {
                return NotFound();
            }

            return View();
        }

        // POST: Yeasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yeast = await _yeastRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> YeastExists(int id)
        { 
            var yeasts = await _yeastRepository.GetAll();
            return yeasts.Exists(y => y.Id == id);
        }
    }
}
