async function getUserProjectData() {
  const url = "http://localhost:5024/api/api/userprojects";
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

async function showUserProjectData() {
  let container = document.getElementById("projectList");
  container.innerHTML = "";

  let data = await getProjectData();
  let projectList = document.createElement("ol");
  container.appendChild(projectList);
  data.forEach((element) => {
    let projectItem = document.createElement("li");
    projectItem.innerHTML = ``;
    projectItem.innerHTML = `
    </button>  Prosjekttittel: <a href="http://localhost:5024/api/userprojects/${element.id}">${element.title}</a>`;
    projectList.appendChild(projectItem);
    projectList.appendChild(document.createElement("br"));
  });
  document.createElement("ul");
}

async function addProject() {
  let userInputTitle = document.getElementById("newProjectInput");
  fetch("http://localhost:5024/api/project", {
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
