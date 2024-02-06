using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TodoHtmx.Web.ViewModels
{
    public class Modal
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";

        public HtmxRequest HtmxRequest { get; set; } = HtmxRequest.hxGet;
        public string HtmxTarget { get; set; } = "";
        public string HtmxUrl { get; set; } = "";
    }

    public class HtmxRequest
    {
        private HtmxRequest(string value) { Value = value; }

        public string Value { get; private set; }

        public static HtmxRequest hxGet { get { return new HtmxRequest("hx-get"); } }
        public static HtmxRequest hxDelete { get { return new HtmxRequest("hx-delete"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
