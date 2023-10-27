using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADOWebForms.Entidades;
using System.Threading.Tasks;

namespace ADOWebForms.ADO
{
    public interface ICRUD
    {
        List<EstatusAlumno> Consultar();
        EstatusAlumno Consultar(int id);
        int Agregar(EstatusAlumno estatus);
        void Actualizar(EstatusAlumno estatus);
        void Eliminar(int id);
    }
}
