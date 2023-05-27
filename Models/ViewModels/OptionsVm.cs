namespace BelRusApiV2.Models.ViewModels
{
    public class OptionsVm
    {
        public List<edu> edus { get; set; }
        public List<soc> socs         { get; set; }
        public List<act> acts         { get; set; }
        public List<regPlc> regPlcs   { get; set; }
        public List<entrPlc> entrPlcs { get; set; }
        public List<partPos> partPoss { get; set; }
        public List<mbrSt> mbrSt      { get; set; }
        public List<crdSt> crdSt { get; set; }
    }
    public class optBs {
        public int id { get; set; }
        public string val { get; set; }
    }
    public class edu : optBs
    {

    }
    public class soc : optBs
    {

    }
    public class act : optBs
    {

    }
   
    public class regPlc : optBs
    {

    }
    public class entrPlc : optBs
    {

    }
    public class partPos : optBs
    {

    }
    public class mbrSt : optBs
    {

    }
    public class crdSt : optBs
    {

    }

}
