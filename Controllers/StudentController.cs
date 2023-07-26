using Microsoft.AspNetCore.Mvc;
using StudentReg.DatabaseContext;
using StudentReg.Models;
using StudentReg.Models.DBEntities;

namespace StudentReg.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentdbContext _context;

        public StudentController(StudentdbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            List<StudentView> studentlist = new List<StudentView>();

            if (students != null)
            {
                foreach (var student in students)
                {
                    var StudentView = new StudentView()
                    {
                        ID = student.ID,
                        Name = student.Name,
                        Email = student.Email,
                        College = student.College,
                    };
                    studentlist.Add(StudentView);
                }
                return View(studentlist);
            }
            return View(studentlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentView studentdata)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = new Students()
                    {
                        Name = studentdata.Name,
                        Email = studentdata.Email,
                        College = studentdata.College,
                    };

                    _context.Students.Add(student);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Student data added successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Data is not valid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();

            }
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            try
            {
                var student = _context.Students.SingleOrDefault(x => x.ID == ID );

                if (student != null)
                {
                    var studentview = new StudentView()
                    {
                        ID = student.ID,
                        Name = student.Name,
                        Email = student.Email,
                        College = student.College,
                    };
                    return View(studentview);
                }
                else
                {
                    TempData["errormessage"] = $"Student details of Id:{ID} is not available";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(StudentView model) {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = new Students()
                    {
                        ID = model.ID,
                        Name = model.Name,
                        Email = model.Email,
                        College = model.College,
                    };
                    _context.Students.Update(student);
                    _context.SaveChanges();
                    TempData["successmessage"] = "Student details updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errormessage"] = "Data is invalid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
                return View();
            }
        }
        public IActionResult Delete(int ID)
        {
            try
            {
                var student = _context.Students.SingleOrDefault(x => x.ID == ID);

                if (student != null)
                {
                    var studentview = new StudentView()
                    {
                        ID = student.ID,
                        Name = student.Name,
                        Email = student.Email,
                        College = student.College,
                    };
                    return View(studentview);
                }
                else
                {
                    TempData["errormessage"] = $"Student details of Id:{ID} is not available";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
            public IActionResult Delete(StudentView model)
            {
            try
                {
                var student = _context.Students.SingleOrDefault(x => x.ID == model.ID);

                if (student != null)
                    {
                        _context.Students.Remove(student);
                        _context.SaveChanges();
                        TempData["successmessage"] = "Student details updated successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["errormessage"] = $"Student details of Id:{model.ID} is not available";
                        return RedirectToAction("Index");
                    }
                }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
                return View();
            }
        }
    }
}

