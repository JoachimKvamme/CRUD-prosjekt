async function getProjectData() {
  const url = "/api/project";
  try {
    const response = await fetch(url);
    if (!response.ok) {
      throw new Error(`Response status: ${response.status}`);
    }

    const json = await response.json();
    console.log(json);
    return json;
  } catch (error) {
    console.error(error.message);
  }
}

async function showProjectData() {
  let container = document.getElementById("projectList");
  container.innerHTML = "";

  let data = await getProjectData();
  let projectList = document.createElement("ol");
  container.appendChild(projectList);
  data.forEach((element) => {
    let projectItem = document.createElement("li");
    projectItem.innerHTML = `Prosjekttittel: <a href="api/userprojects/${element.id}">${element.title}</a>`;
    projectList.appendChild(projectItem);
    projectList.appendChild(document.createElement("br"));
  });
  document.createElement("ul");
}

async function getBookData() {
  const url = "/api/books";
  try {
    const response = await fetch(url);
    if (!response.ok) {
      throw new Error(`Response status: ${response.status}`);
    }

    const json = await response.json();
    console.log(json);
    return json;
  } catch (error) {
    console.error(error.message);
  }
}

async function showBookData() {
  let container = document.getElementById("bookList");
  container.innerHTML = "";

  let data = await getBookData();
  let bookList = document.createElement("ol");
  container.appendChild(bookList);
  data.forEach((element) => {
    let bookItem = document.createElement("li");
    bookItem.innerText = `Tittel: ${element.title}, 
      Forfatternavn: ${element.firstNameAuthor}, ${element.lastNameAuthor},
      Utgivelsesår: ${element.year},
      Forlag: ${element.publisher},
      Sted: ${element.place}`;

    bookList.appendChild(bookItem);
    bookList.appendChild(document.createElement("br"));
  });
}

async function addProject(urlId, data) {
  let url = `/api/project/{id}`;
  // Default options are marked with *
  const response = await fetch(url, {
    method: "POST", // *GET, POST, PUT, DELETE, etc.
    headers: {
      "Content-Type": "application/json",
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    body: JSON.stringify(data), // body data type must match "Content-Type" header
  });
  return response.json(); // parses JSON response into native JavaScript objects
}
