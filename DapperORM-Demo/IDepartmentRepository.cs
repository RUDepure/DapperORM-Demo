using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM_Demo
{
    interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments(); //Stubbed out method
    }
}
