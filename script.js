function readTextFile(file){
    var rawFile = new XMLHttpRequest();
    rawFile.open("GET", file, false);
    rawFile.onreadystatechange = function ()
    {
        if(rawFile.readyState === 4)
        {
            if(rawFile.status === 200 || rawFile.status == 0)
            {
                var allText = rawFile.responseText;
                alert(allText);
            }
        }
    }
  
  rawFile.send(null);
}

function writeToCodeElement(text) {
    const codeElement = document.querySelector('code');
    codeElement.textContent = text;
  }

  writeToCodeElement(readTextFile("https://raw.githubusercontent.com/IZvX/ImYfz.github.io/master/test.cs"))
  var codeElements = document.getElementsByTagName("code");
  for (var i = 0; i < codeElements.length; i++) {
    var codeElement = codeElements[i];
    var pathAttribute = codeElement.getAttribute("path");
    if (pathAttribute) {
      console.log(pathAttribute);
      codeElement.innerHTML = readTextFile(codeElement.getAttribute("path"));
    }
  }