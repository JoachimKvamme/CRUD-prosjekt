async function getBookData() {
  const url = "http://localhost:5024/api/books";
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
    let removeBook = document.createElement("button");
    removeBook.innerHTML = `<button id="${element.id}" class="btn" onclick="removeBook(this.id)">
      <i class="fa fa-trash"></i>`;

    bookItem.innerText = `Tittel: ${element.title}, 
      Forfatternavn: ${element.firstNameAuthor}, ${element.lastNameAuthor},
      Utgivelsesår: ${element.year},
      Forlag: ${element.publisher},
      Sted: ${element.place}`;

    bookList.appendChild(bookItem);
    bookList.appendChild(removeBook);
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

  fetch("http://localhost:5024/api/books", {
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

async function removeBook(id) {
  console.log(id);

  fetch(`http://localhost:5024/api/books/${id}`, {
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
  await showBookData();
  location.reload(true);
}
