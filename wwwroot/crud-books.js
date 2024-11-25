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
