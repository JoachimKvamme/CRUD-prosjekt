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
    bookItem.innerText = ` ${document.createElement("button")} Tittel: ${
      element.title
    }, 
      Forfaernavn: ${element.firstNameAuthor}, ${element.lastNameAuthor},
      Utgivelsesår: ${element.year},
      Forlag: ${element.publisher},
      Sted: ${element.place}`;

    bookList.appendChild(bookItem);
    bookItem.appendChild(removeButton);
    bookList.appendChild(document.createElement("br"));
  });
}

async function addBookForm() {
  document.getElementById("bookForm").style.display = "block";
}

function closeAddBookForm() {
  document.getElementById("bookForm").style.display = "none";
}

async function addBook() {
  const title = document.getElementById("title").value;
  const firstName = document.getElementById("firstName").value;
  const lastName = document.getElementById("lastName").value;
  const inputYear = document.getElementById("year").value;
  const publisher = document.getElementById("publisher").value;
  const place = document.getElementById("place").value;

  fetch("api/books", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      title: `${title}`,
      firstNameAuthor: `${firstName}`,
      lastNameAuthor: `${lastName}`,
      year: `${inputYear}`,
      publisher: `${publisher}`,
      place: `${place}`,
    }),
  })
    .then((response) => response.json())
    .then((data) => console.log(data))
    .catch((error) => console.error("Error:", error));
}
