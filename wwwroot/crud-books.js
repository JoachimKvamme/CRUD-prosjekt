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

async function addBookForm() {
  document.getElementById("myForm").style.display = "block";
}

function closeAddBookForm() {
  document.getElementById("myForm").style.display = "none";
}

async function addBook() {
  document
    .getElementById("bookForm")
    .addEventListener("submit", function (event) {
      event.preventDefault(); // Prevent form submission
      const title = document.getElementById("title").value;
      const firstName = document.getElementById("firstName").value;
      const lastName = document.getElementById("lastName").value;
      const year = document.getElementById("year").value;
      const publisher = document.getElementById("publisher").value;
      const place = document.getElementById("place").value;
    });

  fetch("api/project", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      title: ``,
      firstNameAuthor: ``,
      lastNameAuthor: ``,
      year: 0,
      publisher: "string",
      place: "string",
    }),
  })
    .then((response) => response.json())
    .then((data) => console.log(data))
    .catch((error) => console.error("Error:", error));
}
