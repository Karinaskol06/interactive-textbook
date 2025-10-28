-- Створення бази даних
CREATE DATABASE interactive_language_learning;
USE interactive_language_learning;

-- Таблиця мов
CREATE TABLE Languages (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL UNIQUE,
    code VARCHAR(5) NOT NULL UNIQUE
);

-- Таблиця користувачів
CREATE TABLE Users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    current_language_id INT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (current_language_id) REFERENCES Languages(id)
);

-- Таблиця секцій
CREATE TABLE Sections (
    id INT AUTO_INCREMENT PRIMARY KEY,
    language_id INT NOT NULL,
    name VARCHAR(50) NOT NULL,
    description TEXT,
    FOREIGN KEY (language_id) REFERENCES Languages(id),
    UNIQUE KEY unique_section_per_language (language_id, name)
);

-- Таблиця тем
CREATE TABLE Topics (
    id INT AUTO_INCREMENT PRIMARY KEY,
    section_id INT NOT NULL,
    title VARCHAR(100) NOT NULL,
    description TEXT,
    order_index INT NOT NULL,
    FOREIGN KEY (section_id) REFERENCES Sections(id)
);

-- Таблиця вправ для словникового запасу
CREATE TABLE VocabularyExercises (
    id INT AUTO_INCREMENT PRIMARY KEY,
    topic_id INT NOT NULL,
    question TEXT NOT NULL,
    correct_answer VARCHAR(255) NOT NULL,
    options TEXT NOT NULL,
    explanation TEXT,
    FOREIGN KEY (topic_id) REFERENCES Topics(id)
);

-- Таблиця вправ для читання
CREATE TABLE ReadingExercises (
    id INT AUTO_INCREMENT PRIMARY KEY,
    topic_id INT NOT NULL,
    title VARCHAR(200) NOT NULL,
    text_content TEXT NOT NULL,
    question TEXT NOT NULL,
    correct_answer VARCHAR(255) NOT NULL,
    options TEXT NOT NULL,
    explanation TEXT,
    FOREIGN KEY (topic_id) REFERENCES Topics(id)
);

-- Таблиця вправ для граматики
CREATE TABLE GrammarExercises (
    id INT AUTO_INCREMENT PRIMARY KEY,
    topic_id INT NOT NULL,
    title VARCHAR(200) NOT NULL,
    explanation TEXT NOT NULL,
    question TEXT NOT NULL,
    correct_answer VARCHAR(255) NOT NULL,
    options TEXT NOT NULL,
    example TEXT,
    FOREIGN KEY (topic_id) REFERENCES Topics(id)
);

-- Таблиця для відстеження прогресу користувача
CREATE TABLE UserProgress (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    exercise_id INT NOT NULL,
    exercise_type ENUM('vocabulary', 'reading', 'grammar') NOT NULL,
    completed BOOLEAN DEFAULT FALSE,
    score INT DEFAULT 0,
    attempts INT DEFAULT 0,
    last_attempt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES Users(id)
);

-- Додаємо мови
INSERT INTO Languages (name, code) VALUES 
('Англійська', 'en'),
('Польська', 'pl'),
('Німецька', 'de');

-- Додаємо секції для кожної мови 
INSERT INTO Sections (language_id, name, description) VALUES 
-- Англійська мова
(1, 'Словниковий запас', 'Розширення словникового запасу'),
(1, 'Читання', 'Вправи для покращення навичок читання'),
(1, 'Граматика', 'Вивчення граматичних правил'),
-- Польська мова
(2, 'Словниковий запас', 'Розширення словникового запасу'),
(2, 'Читання', 'Вправи для покращення навичок читання'),
(2, 'Граматика', 'Вивчення граматичних правил'),
-- Німецька мова
(3, 'Словниковий запас', 'Розширення словникового запасу'),
(3, 'Читання', 'Вправи для покращення навичок читання'),
(3, 'Граматика', 'Вивчення граматичних правил');

-- Додаємо теми для англійської мови
INSERT INTO Topics (section_id, title, description, order_index) VALUES 
-- Словниковий запас (англійська)
(1, 'Їжа та напої', 'Слова пов''язані з їжею та напоями', 1),
(1, 'Подорожі', 'Слова для подорожей та транспорту', 2),
(1, 'Робота', 'Професійна лексика', 3),
(1, 'Сім''я та друзі', 'Лексика про стосунки', 4),
-- Читання (англійська)
(2, 'Короткі тексти', 'Прості тексти для рівня B1', 1),
(2, 'Діалоги', 'Щоденні розмови', 2),
(2, 'Новини', 'Адаптовані новинні статті', 3),
(2, 'Опис подій', 'Тексти про події та враження', 4),
-- Граматика (англійська)
(3, 'Present Simple', 'Теперішній простий час', 1),
(3, 'Артиклі', 'Використання a/an/the', 2),
(3, 'Модальні дієслова', 'Can, could, should, must', 3),
(3, 'Минулі часи', 'Past Simple та Past Continuous', 4);

-- Додаємо вправи для словникового запасу (англійська)
INSERT INTO VocabularyExercises (topic_id, question, correct_answer, options, explanation) VALUES 
(1, 'Choose the correct word for "напій"', 'beverage', 'cola,beverage,juice,smoothie', 'Cola - кола кола, beverage - напій, juice - сік, smoothie - смузі'),
(1, 'What is "meal" in Ukrainian?', 'прийом їжі', 'рецепт,страва,прийом їжі,порція', 'Meal перекладається як "прийом їжі"'),
(2, 'Choose the correct translation for "подорож"', 'journey', 'departure,arrival,tour,journey', 'Departure - відправлення, arrival - прибуття, tour - тур, journey - подорож'),
(4, 'What is the English word for "родичі"?', 'relatives', 'siblings,parents,cousins,relatives', 'Siblings - брати і сестри, parents - батьки, cousins - кузени, relatives - родичі');

-- Додаємо вправи для читання (англійська)
INSERT INTO ReadingExercises (topic_id, title, text_content, question, correct_answer, options, explanation) VALUES 
(5, 'My Daily Routine', 'I usually wake up at 7 am. Then I have breakfast and go to work. After work, I like to read books or watch TV. On weekends, I often meet friends or go for a walk in the park.', 'What time does the person wake up?', '7 am', '6 am,7 am,8 am,9 am', 'У тексті сказано: "I usually wake up at 7 am"'),
(5, 'Weather in London', 'London is known for its rainy weather. It often rains throughout the year, but summers can be quite warm. The temperature in winter rarely drops below zero.', 'What is London weather famous for?', 'Rain', 'Snow,Sun,Rain,Wind', 'У тексті сказано: "London is known for its rainy weather"'),
(6, 'Restaurant Conversation', 'Customer: Can I see the menu, please? Waiter: Of course, here you are. Customer: Thank you. I''ll have the chicken pasta. Waiter: Excellent choice. Would you like anything to drink?', 'What does the customer order?', 'Chicken pasta', 'Beef steak,Chicken pasta,Fish soup,Vegetable salad', 'Клієнт каже: "I''ll have the chicken pasta"');

-- Додаємо вправи для граматики (англійська)
INSERT INTO GrammarExercises (topic_id, title, explanation, question, correct_answer, options, example) VALUES 
(9, 'Present Simple', 'Present Simple використовується для регулярних дій та фактів', 'Choose the correct form: She ___ to school every day.', 'goes', 'go,goes,going,went', 'She goes to school every day. - Вона ходить до школи кожного дня.'),
(10, 'Articles', 'Артикль "the" використовується для конкретних об''єктів', 'Choose the correct article: I saw ___ beautiful bird in ___ garden.', 'a,the', 'a,a,the,the,the,a', 'I saw a beautiful bird in the garden. - Я побачив гарного птаха в саду.'),
(11, 'Modal Verbs', 'Can використовується для можливості або вміння', 'Choose the correct modal verb: She ___ speak three languages.', 'can', 'can,must,should,could', 'She can speak three languages. - Вона вміє розмовляти трьома мовами.');