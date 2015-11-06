using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace EvilTagHelpers
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class BlinkTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var tagId = "b" + System.Guid.NewGuid().ToString().Replace("-", "");

            output.TagName = "span";
            output.Attributes["id"] = tagId;
            output.PostElement.SetContentEncoded($@"<script>
function blink{tagId}() {{
    var el = document.getElementById('{tagId}');
    if( el && el.style.visibility == 'hidden')    
        el.style.visibility = 'visible';
    else 
        el.style.visibility = 'hidden';
}}
setInterval(blink{tagId}, 1000);
</script>");

        }

    }
}
