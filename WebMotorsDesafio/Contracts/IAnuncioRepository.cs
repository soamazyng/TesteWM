using System.Collections.Generic;
using WebMotorsDesafio.Entities;

namespace WebMotorsDesafio.Contracts
{
    public interface IAnuncioRepository
    {
        void InsertAnuncio(AnuncioWebmotors anunciowebMotors);
       IEnumerable<AnuncioWebmotors> GetAnuncios();
        AnuncioWebmotors GetAnuncioById(int Id);
        void UpdateAnuncio(AnuncioWebmotors anuncioWebmotors);
        void DeleteAnuncio(int Id);
    }
}