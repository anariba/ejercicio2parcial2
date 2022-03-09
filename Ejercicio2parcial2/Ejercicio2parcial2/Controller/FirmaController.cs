using System;
using System.Collections.Generic;
using System.Text;
using Ejercicio2parcial2.Models;
using SQLite;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;

namespace Ejercicio2parcial2.Controller
{
  public   class FirmaController
    {
        readonly SQLiteAsyncConnection db;

        public FirmaController() { }

        public FirmaController(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);
            // creacion d tablas de la base de datos
            db.CreateTableAsync<Firmas>();
        }


        //retorna la tabla sitios con una lista
        public Task<List<Firmas>> ListaFirma()
        {
            return db.Table<Firmas>().ToListAsync();
        }

        public Task<Firmas> GetSignatureByCode(int signatureCode)
        {
            return db.Table<Firmas>()
                .Where(i => i.Id == signatureCode)
                .FirstOrDefaultAsync();
        }




        //guardar un sitio
        public Task<Int32> guardar(Firmas firma)
        {

            if (firma.Id != 0)
            {
                return db.UpdateAsync(firma);
            }
            else
            {
                return db.InsertAsync(firma);
            }

        }

        //Eliminar sitio

        public Task<Int32> borrar(Firmas firma)
        {
            return db.DeleteAsync(firma);

        }


        //imagen 64


    }
}
