using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace EvilTagHelpers
{
    [HtmlTargetElement("body")]
    public class MirrorTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (10%new Random().Next(1,10) != 0) return; // Only implements the mirror 10% of the time

            var style = "transform: scaleX(-1);";
            var currentStyle = context.AllAttributes["style"];
            if (currentStyle != null)
            {
                style += currentStyle;
            }
            output.Attributes["style"] = new TagHelperAttribute("style", style);
        }
    }
}
