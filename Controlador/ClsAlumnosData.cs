using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Controlador
{
    public class ClsAlumnosData
    {
        Datos cnGeneral = null;
        ClsAlumnos objAlumnos = null;
        DataTable tblDatos = null;

        public ClsAlumnosData(ClsAlumnos parObjAlumno)
        {
            objAlumnos = parObjAlumno;
        }

        public DataTable Listar()
        {
            tblDatos = new DataTable();
            try
            {
                cnGeneral = new Datos();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter();
                parametros[0].ParameterName = "@opc";
                parametros[0].SqlDbType = SqlDbType.Int;
                parametros[0].SqlValue = objAlumnos.opc;
                tblDatos = cnGeneral.RetornaTabla(parametros, "opcionesCrud");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return tblDatos;
        }

        public void GuardarDatos()
        {
            try
            {
                cnGeneral = new Datos();
                SqlParameter[] parametros = new SqlParameter[6];
                parametros[0] = new SqlParameter();
                parametros[0].ParameterName = "@opc";
                parametros[0].SqlDbType = SqlDbType.Int;
                parametros[0].SqlValue = objAlumnos.opc;

                parametros[1] = new SqlParameter();
                parametros[1].ParameterName = "@Nuip";
                parametros[1].SqlDbType = SqlDbType.Int;
                parametros[1].SqlValue = objAlumnos.Nuip;

                parametros[2] = new SqlParameter();
                parametros[2].ParameterName = "@Nombre";
                parametros[2].SqlDbType = SqlDbType.VarChar;
                parametros[2].Size = 50;
                parametros[2].SqlValue = objAlumnos.Nombre;

                parametros[3] = new SqlParameter();
                parametros[3].ParameterName = "@Apellido";
                parametros[3].SqlDbType = SqlDbType.VarChar;
                parametros[3].Size = 50;
                parametros[3].SqlValue = objAlumnos.apellido;

                parametros[4] = new SqlParameter();
                parametros[4].ParameterName = "@edad";
                parametros[4].SqlDbType = SqlDbType.TinyInt;
                parametros[4].SqlValue = objAlumnos.Edad;

                parametros[5] = new SqlParameter();
                parametros[5].ParameterName = "@grado";
                parametros[5].SqlDbType = SqlDbType.TinyInt;
                parametros[5].SqlValue = objAlumnos.Grado;

                cnGeneral.EjecutarSP(parametros, "opcionesCrud");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void EliminarDatos()
        {
            try
            {
                cnGeneral = new Datos();
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter();
                parametros[0].ParameterName = "@opc";
                parametros[0].SqlDbType = SqlDbType.Int;
                parametros[0].SqlValue = objAlumnos.opc;

                parametros[1] = new SqlParameter();
                parametros[1].ParameterName = "@Nuip";
                parametros[1].SqlDbType = SqlDbType.Int;
                parametros[1].SqlValue = objAlumnos.Nuip;

                cnGeneral.EjecutarSP(parametros, "opcionesCrud");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
