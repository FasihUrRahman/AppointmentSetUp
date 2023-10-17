using Appoinment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appoinment.Repository
{
    public interface IHospital
    {
        List<Doctor> GetDoctors();
        Doctor GetDoctor(int id);
        void AddEditDoctor(Doctor doctor);
        void RemoveDoctor(int id);
        List<Patient> GetPatients();
        Patient GetPatient(int id);
        void AddEditPatient(Patient patient);
        void RemovePatent(int id);
    }
}
