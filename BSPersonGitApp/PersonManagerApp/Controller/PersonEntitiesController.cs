using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManagerApp.Model;

namespace PersonManagerApp
{
    public class PersonEntitiesController : Controller
    {
        private readonly PersonContext _context;

        public PersonEntitiesController(PersonContext context)
        {
            _context = context;
        }

        // GET: PersonEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Person.ToListAsync());
        }

        // GET: PersonEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonEntity personEntity = await _context.Person.SingleOrDefaultAsync(m => m.Id == id);

            if (personEntity == null)
            {
                return NotFound();
            }

            return View(personEntity);
        }

        // GET: PersonEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePerson([Bind("Id,FirstName,LastName,Title,Age,City,PostCode")] PersonEntity personEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }

        // GET: PersonEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonEntity personEntity = await _context.Person.SingleOrDefaultAsync(m => m.Id == id);

            if (personEntity == null)
            {
                return NotFound();
            }
            return View(personEntity);
        }

        // POST: PersonEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPerson(int id,PersonEntity personEntity)
        {
            if (id != personEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonEntityExists(personEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personEntity);
        }

        // GET: PersonEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personEntity = await _context.Person
                .SingleOrDefaultAsync(m => m.Id == id);
            if (personEntity == null)
            {
                return NotFound();
            }

            return View(personEntity);
        }

        // POST: PersonEntities/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personEntity = await _context.Person.SingleOrDefaultAsync(m => m.Id == id);
            _context.Person.Remove(personEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonEntityExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}
