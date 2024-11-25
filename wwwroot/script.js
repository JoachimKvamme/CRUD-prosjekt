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
  });
  document.createElement("ul");
}

async function getBookData() {
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

async function showBookData() {
  let container = document.getElementById("projectList");
  container.innerHTML = "";

  let data = await getProjectData();
  let projectList = document.createElement("ol");
  container.appendChild(projectList);
  data.forEach((element) => {
    let projectItem = document.createElement("li");
    projectItem.innerHTML = `${element.title}n\
    ${element.firstNameAuthor}n\
    ${element.lastNameAuthor}n\
    ${element.year}n\
    ${element.publisher}n\
    ${element.place}n\
    `;
    projectList.appendChild(projectItem);
  });
  document.createElement("ul");
}
