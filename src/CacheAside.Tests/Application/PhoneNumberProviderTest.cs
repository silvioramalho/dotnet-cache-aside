using CacheAside.Application.Providers;

namespace CacheAside.Tests.Application
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PhoneNumberProvider_ShouldGeneratePhoneNumberWith8Digits()
        {
            var phone = PhoneNumberProvider.GetRandom(false);
            Assert.That(phone, Has.Length.EqualTo(12));
            Assert.Pass(phone);
        }

        [Test]
        public void PhoneNumberProvider_ShouldGeneratePhoneNumberWith9Digits()
        {
            var phone = PhoneNumberProvider.GetRandom(true);
            Assert.That(phone, Has.Length.EqualTo(13));
            Assert.Pass(phone);
        }
    }
}