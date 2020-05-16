using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xunit;

namespace DesignPatterns.Singleton.Tests
{
    public class SingletonTests
    {
        [Fact]
        public void GetInstance_WhenTwoInstances_ShouldBeEqual()
        {
            var instanceA = SoundPathProvider.Instance;
            var instanceB = SoundPathProvider.Instance;

            Assert.Equal(instanceA, instanceB);
        }

        [Fact]
        public void AddSound_WhenTwoInstances_ShouldContainsTwoSounds()
        {
            var instanceA = SoundPathProvider.Instance;
            var instanceB = SoundPathProvider.Instance;

            instanceA.Add("sound 1", "fake path");
            instanceB.Add("sound 2", "fake path");

            Assert.Equal(2, instanceA.SoundCount());
        }

        [Fact]
        public void GetInstance_WhenManyInstances_AndDifferentThreads_ShouldBeEqual()
        {
            var listTasks = new List<Task<Guid>>();

            for(int i = 0; i < 100; i ++)
            {
                int index = i;
                var task = Task.Run(() =>
                {
                    var instance = SoundPathProvider.Instance;
                    instance.Add($"Sound[{index}]", "fake path");
                    return instance.Id;
                });

                listTasks.Add(task);
            }

            Task.WhenAll(listTasks).Wait();

            var instance = SoundPathProvider.Instance;

            Assert.True(listTasks.All(x => x.Result == listTasks[0].Result));
            Assert.Equal(100, instance.SoundCount());
        }
    }
}
