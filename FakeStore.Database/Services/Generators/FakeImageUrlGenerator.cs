using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStore.Database.Services.Generators
{
    internal class FakeImageUrlGenerator: IFakeImageUrl
    {
        private readonly Random random = new Random();

        public string GetFakeImageUrl(int ImageWidth, int ImageHeight)
        {
            throw new NotImplementedException();
        }

        public List<string> GetImagesUrl(int NumberOfImages, int ImageWidth, int ImageHeight)
        {
            throw new NotImplementedException();
        }

        private int GenerateRandomNumber(int minValue, int maxValue)
        {
            // Asegurarse de que el rango es válido (minValue debe ser menor que maxValue)
            if (minValue >= maxValue)
            {
                throw new ArgumentException("minValue debe ser menor que maxValue");
            }

            // Generar un número aleatorio dentro del rango especificado
            return random.Next(minValue, maxValue);
        }
    }

    public interface IFakeImageUrl
    {
        List<string> GetImagesUrl(int NumberOfImages, int ImageWidth, int ImageHeight);
        string GetFakeImageUrl(int ImageWidth, int ImageHeight);
    }
}
