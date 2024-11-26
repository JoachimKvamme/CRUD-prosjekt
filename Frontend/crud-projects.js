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
    projectItem.innerHTML = ``;
    projectItem.innerHTML = `<button id="${element.id}" class="btn" onclick="removeProject(this.id)">
      <i class="fa fa-trash"></i>
    </button>  Prosjekttittel: <a href="api/userprojects/${element.id}">${element.title}</a>`;
    projectList.appendChild(projectItem);
    projectList.appendChild(document.createElement("br"));
  });
  document.createElement("ul");
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
  await showProjectData();
  document.getElementById("newProjectInput").innerHTML = "";
  location.reload(true);
}

async function removeProject(id) {
  fetch(`api/project/${id}`, {
    method: "DELETE",
  })
    .then((response) => {
      if (response.ok) {
        console.log("Delete successful");
      } else {
        console.error("Delete failed");
      }
    })
    .catch((error) => console.error("There was an error!", error));
  await showProjectData();
  location.reload(true);
}
