function readTextFile(file) {
  var rawFile = new XMLHttpRequest();
  var text = "";
  rawFile.open("GET", file, false);
  rawFile.onreadystatechange = function () {
      if(rawFile.readyState === 4) {
          if(rawFile.status === 200 || rawFile.status == 0) {
              text = rawFile.responseText;
          }
      }
  }
  rawFile.send(null);
  return text
}

function writeToCodeElement(text) {
  const codeElement = document.querySelector('code');
  codeElement.innerHTML = text;
}

var codeElements = document.getElementsByTagName("code");
for (var i = 0; i < codeElements.length; i++) {
  var codeElement = codeElements[i];
  var pathAttribute = codeElement.getAttribute("path");
  if (pathAttribute) {
      codeElement.innerHTML = readTextFile(codeElement.getAttribute("path"));
  }
}