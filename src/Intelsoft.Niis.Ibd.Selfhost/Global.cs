using System;
using Autofac;

namespace Intelsoft.Niis.Ibd.Selfhost
{
    // Костыль для получения контейнера.
    public sealed class Global
    {
        private static readonly Lazy<Global> Lazy = new Lazy<Global>(() => new Global());

        private Global()
        {
            Container = Bootstrapper.BuildContainer();
        }

        public static Global Instance => Lazy.Value;

        public IContainer Container { get; }
    }
}
