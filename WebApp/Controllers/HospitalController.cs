using Appoinment.Models;
using Appoinment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IHospital _hospital;
        public HospitalController(IHospital hospital)
        {
            _hospital = hospital;
        }
        [HttpGet]
        public IActionResult Doctors()
        {
            return View(_hospital.GetDoctors());
        }
        [HttpGet]
        public IActionResult AddEditDoctor(int id = 0)
        {
            return View(_hospital.GetDoctor(id));
        }
        [HttpPost]
        public IActionResult AddEditDoctor(Doctor doctor)
        {
            _hospital.AddEditDoctor(doctor);
            return RedirectToAction("Doctors");
        }
        [HttpGet]
        public IActionResult DeleteDoctor(int id)
        {
            _hospital.RemoveDoctor(id);
            return RedirectToAction("Doctors");
        }
        public IActionResult Patients()
        {
            return View(_hospital.GetPatients());
        }
        [HttpGet]
        public IActionResult AddEditPatients(int id = 0)
        {
            return View(_hospital.GetPatient(id));
        }
        [HttpPost]
        public IActionResult AddEditPatient(Patient patient)
        {
            _hospital.AddEditPatient(patient);
            return RedirectToAction("Patients");
        }
        [HttpGet]
        public IActionResult DeletePatient(int id)
        {
            _hospital.RemovePatent(id);
            return RedirectToAction("Patients");
        }
    }
}
