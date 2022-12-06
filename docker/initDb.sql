CREATE TABLE flashcard (
    id          SERIAL PRIMARY KEY,
    front       varchar(100),
    back        text
);

CREATE TABLE stack (
    id              SERIAL PRIMARY KEY,
    title           varchar(40)
);

CREATE TABLE flashcards(
    id              SERIAL PRIMARY KEY,
    stack_id        int REFERENCES stack ON DELETE CASCADE,
    flashcard_id    int REFERENCES flashcard ON DELETE CASCADE,
    UNIQUE (stack_id, flashcard_id)
);

INSERT INTO flashcard (front, back)
VALUES ('Beer','Пиво'),('Bear','Медведь'),('Language','Язык');

INSERT INTO stack (title)
VALUES ('En-RU');

INSERT INTO flashcards(stack_id,flashcard_id)
VALUES (1,1), (1,2), (1,3);
