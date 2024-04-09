using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace Infrastructure.Utility
{
    public class FakeDataGenerator
    {
        private readonly Faker _faker;
        private Dictionary<string, Func<Faker, object>> fieldGenerators = new Dictionary<string, Func<Faker, object>>();

        public FakeDataGenerator(Faker faker)
        {
            _faker = faker;
        }

        public T GenerateFakeClassData<T>() where T : class, new()
        {
            T instance = new T();
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                // Generating fake data for each property
                var fakeValue = GenerateFakeValue(property);
                property.SetValue(instance, fakeValue);
            }

            return instance;
        }

        private object GenerateFakeValue(PropertyInfo property)
        {
            Type type = property.PropertyType;

            if (type == typeof(int))
            {
                if (property.Name == "FkKodNapa")
                {
                    return _faker.Random.Int(1, 4);
                }
                return _faker.Random.Int(1, 100);
            }
            else if (type == typeof(int?))
            {
                return null;
            }
            else if (type == typeof(string))
            {
                if (property.Name == "IpAddress")
                {
                    return _faker.Internet.Ip();
                }
                else if (property.Name == "TeurMikumHaessek")
                {
                    return _faker.Company.CompanyName();
                }
                else if (property.Name == "TeudatZehutEsek")
                {
                    return _faker.Random.UInt(1, 999999999).ToString();    
                }
                else if (property.Name == "ShemMispaha")
                {
                    return _faker.Name.LastName();
                }
                else if (property.Name == "ShemPrati")
                {
                    return _faker.Name.FindName();
                }
                else if (property.Name == "MisparTelephon" || property.Name == "MisparTelephon2" || property.Name == "Telephone1" || property.Name == "Telephone2")
                {
                    string tel = _faker.Random.Long(100001, 199999).ToString();
                    var updatedTel = "054" + tel;
                    return updatedTel;
                }
              

                else if (property.Name == "ShemEssek")
                {
                    var shemEssek = $"{_faker.Company.CompanyName()}_{_faker.Random.AlphaNumeric(10)}";
                    return shemEssek;
                }
                else return _faker.Random.AlphaNumeric(10);

            }
            else if(type == typeof(decimal))
            {
                return _faker.Random.Decimal(0.1m, 99.9m);
            }
            else if (type == typeof(decimal?))
            {
                return null;
            }
            else if (type.IsClass && !type.IsGenericType && type != typeof(string))
            {
                return null;
            }
            else if (type == typeof(DateTime))
            {
                return _faker.Date.Recent();
            }
            else if (type == typeof(DateTime?))
            {
                return null;
            }
            else if (type.IsEnum)
            {
                var enumValues = Enum.GetValues(type);
                return enumValues.GetValue(_faker.Random.Int(0, enumValues.Length - 1));
            }
            else
            {
                return Activator.CreateInstance(type);
            }
        }


    }
}
