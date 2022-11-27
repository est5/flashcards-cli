CREATE TABLE flashcard (
    id          SERIAL PRIMARY KEY,
    front       varchar(100),
    back        text
);

CREATE TABLE stack (
    id          SERIAL PRIMARY KEY,
    title       varchar(40),
    flashcards  integer[]
);

CREATE TABLE game_session (
    id          SERIAL PRIMARY KEY,
    stack_id    int REFERENCES stack ON DELETE CASCADE,
    points      integer,
    date        timestamp without time zone NOT NULL DEFAULT (current_timestamp AT TIME ZONE 'GMT+3')
);

INSERT INTO flashcard (front, back)
VALUES ('Beer','Пиво'),('Bear','Медведь'),('Language','Язык');

INSERT INTO stack (title, flashcards)
VALUES ('En-RU','{1,2,3}');
