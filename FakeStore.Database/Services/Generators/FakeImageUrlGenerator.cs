namespace FakeStore.Database.Services.Generators
{
    internal class FakeImageUrlGenerator: IFakeImageUrl
    {
        private readonly Random random = new Random();

        public string GetFakeImageUrl(int ImageWidth, int ImageHeight)
        {
            return $"https://picsum.photos/{ImageWidth}/{ImageHeight}?random={GenerateRandomNumber(1, 10000)}";
        }

        public List<string> GetImagesUrl(int NumberOfImages, int ImageWidth, int ImageHeight)
        {
            List<string> images = new List<string>();

            for (int i = 0; i < NumberOfImages; i++)
            {
                images.Add($"https://picsum.photos/{ImageWidth}/{ImageHeight}?random={GenerateRandomNumber(1, 10000)}");
            }

            return images;
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
