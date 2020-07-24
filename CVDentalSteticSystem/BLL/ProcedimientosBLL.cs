﻿using CVDentalSteticSystem.DAL;
using CVDentalSteticSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CVDentalSteticSystem.BLL
{
    public class ProcedimientosBLL
    {
        public static bool Guardar(Procedimientos procedimiento)
        {
            if (!Existe(procedimiento.ProcedimientoId))
                return Insertar(procedimiento);
            else
                return Modificar(procedimiento);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Procedimientos.Any(e => e.ProcedimientoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        private static bool Insertar(Procedimientos procedimiento)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                Pacientes paciente = PacientesBLL.Buscar(procedimiento.PacienteId);
                paciente.Balance += procedimiento.Monto;

                contexto.Procedimientos.Add(procedimiento);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Procedimientos procedimiento)
        {
            Contexto contexto = new Contexto();

            bool paso = false;

            var anterior = ProcedimientosBLL.Buscar(procedimiento.ProcedimientoId);

            try
            {
                Pacientes paciente = PacientesBLL.Buscar(procedimiento.PacienteId);
                paciente.Balance -= anterior.Monto; //todo: Revisar funcionamiento
                paciente.Balance += procedimiento.Monto;



                contexto.Database.ExecuteSqlRaw($"Delete FROM ProcedimientosDetalle Where ProcedimientoId = {procedimiento.ProcedimientoId}");

                foreach (var item in procedimiento.ProcedimientoDetalle)
                {
                    contexto.Database.ExecuteSqlRaw($"INSERT INTO ProcedimientosDetalles (ProcedimientosDetalleId, ProcedimientoId, CitaId, Descripcion) values({item.ProcedimientosDetalleId},{item.ProcedimientoId},{1},{item.Descripcion})"); //Donde esta uno, colocar CitaId luego de creada Citas
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(procedimiento).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var procedimiento = contexto.Procedimientos.Find(id);

                Pacientes paciente = PacientesBLL.Buscar(procedimiento.PacienteId);
                paciente.Balance -= procedimiento.Monto;

                if (procedimiento != null)
                {
                    contexto.Procedimientos.Remove(procedimiento);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Procedimientos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Procedimientos procedimiento;

            try
            {
                procedimiento = contexto.Procedimientos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return procedimiento;
        }

        public static List<Procedimientos> GetList(Expression<Func<Procedimientos, bool>> criterio)
        {
            List<Procedimientos> lista = new List<Procedimientos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Procedimientos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static List<Procedimientos> GetProcedimientos()
        {
            List<Procedimientos> lista = new List<Procedimientos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Procedimientos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

    }
}