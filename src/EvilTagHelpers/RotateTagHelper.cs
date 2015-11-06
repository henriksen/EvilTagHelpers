using System;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace EvilTagHelpers
{
    [HtmlTargetElement("body")]
    public class RotateTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
            if (10%new Random().Next(2,11) != 0) return; // Only implements the mirror 10% of the time      
            output.PostElement.SetContentEncoded($@"
<script>
var rotate = 0;
function rotateBody() {{
    if (rotate>359) {{ rotate=0; }}

    var rotation = 'rotate('+ (rotate += 0.1) +'deg)'
    var el = document.getElementsByTagName('body')[0];
    el.style = el.style || {{}};
    el.style.transform = el.style.transform || '';
    arr = el.style.transform.split(' ');
    var registered = false; 
    for(var i=0;i<arr.length;i++)
    {{
        if(arr[i].slice(0, 6) == 'rotate') {{
            arr[i] = rotation;
            registered=true;
         }}

    }}
    if (!registered) {{ arr.push(rotation); }}
    

    el.style.transform = arr.join(' ');
}}
setInterval(rotateBody, 300);
</script>");

        }

    }
}
