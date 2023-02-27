using WebApplicationNet6.Interface;

namespace WebApplicationNet6.Class
{
    public class SampleClass : IScoped, ISingleton, ITransient
    {
        public int SampleScoped { get; set; }
        public int SampleSingleton { get; set; }
        public int SampleTransient { get; set; }
    }
}
