using Appoinment.Models;
using Appointment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appoinment.Repository.Implimentation
{
    public class HospitalRepository : IHospital
    {
        private readonly AppointmentContext _db;
        public HospitalRepository(AppointmentContext db)
        {
            _db = db;
        }
        public void AddEditDoctor(Doctor doctor)
        {
            _db.Doctors.Update(doctor);
            _db.SaveChanges();
        }

        public void AddEditPatient(Patient patient)
        {
            _db.Patients.Update(patient);
            _db.SaveChanges();
        }

        public Doctor GetDoctor(int id)
        {
            return _db.Doctors.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Doctor> GetDoctors()
        {
            return _db.Doctors.ToList();
        }

        public Patient GetPatient(int id)
        {
            return _db.Patients.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Patient> GetPatients()
        {
            return _db.Patients.ToList();
        }

        public void RemoveDoctor(int id)
        {
            Doctor doctorId = _db.Doctors.Where(x => x.Id.Equals(id)).FirstOrDefault();
            _db.Remove(doctorId);
            _db.SaveChanges();
        }

        public void RemovePatent(int id)
        {
            Patient patientId = _db.Patients.Where(x => x.Id.Equals(id)).FirstOrDefault();
            _db.Remove(patientId);
            _db.SaveChanges();
        }
    }
}
