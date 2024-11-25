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

async function addProject() {
  let userInputTitle = document.getElementById("newProjectInput");
  fetch("api/project", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      title: `${userInputTitle.value}`,
    }),
  })
    .then((response) => response.json())
    .then((data) => console.log(data))
    .catch((error) => console.error("Error:", error));
}
