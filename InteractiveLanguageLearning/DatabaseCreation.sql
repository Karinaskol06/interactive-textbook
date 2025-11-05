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

INSERT INTO Topics (section_id, title, description, order_index) VALUES 
-- Словниковий запас (німецька) - секція має ID 7
(7, 'Reisen und Transport', 'Слова для подорожей та транспорту', 1),
(7, 'Essen und Gastronomie', 'Слова пов''язані з їжею та ресторанами', 2),
(7, 'Arbeit und Karriere', 'Професійна лексика', 3),
(7, 'Soziale Beziehungen und Emotionen', 'Лексика про стосунки та емоції', 4);

-- Додаємо вправи для словникового запасу (англійська)
INSERT INTO VocabularyExercises (topic_id, question, correct_answer, options, explanation) VALUES 
(1, 'Choose the correct word for "напій"', 'beverage', 'cola,beverage,juice,smoothie', 'Cola - кола кола, beverage - напій, juice - сік, smoothie - смузі'),
(1, 'What is "meal" in Ukrainian?', 'прийом їжі', 'рецепт,страва,прийом їжі,порція', 'Meal перекладається як "прийом їжі"'),
(2, 'Choose the correct translation for "подорож"', 'journey', 'departure,arrival,tour,journey', 'Departure - відправлення, arrival - прибуття, tour - тур, journey - подорож'),
(4, 'What is the English word for "родичі"?', 'relatives', 'siblings,parents,cousins,relatives', 'Siblings - брати і сестри, parents - батьки, cousins - кузени, relatives - родичі');
INSERT INTO VocabularyExercises (topic_id, question, correct_answer, options, explanation) VALUES 
(1, 'Choose the correct translation for "appetizer"', 'закуска', 'десерт,основна страва,закуска,напій', 'Appetizer - закуска, яку подають перед основним стравою'),
(1, 'What does "bland" mean in food context?', 'несолодкий/пресний', 'гострий,солодкий,кислий,несолодкий/пресний', 'Bland - їжа без вираженого смаку, несолодка'),
(1, 'What is the English for "приправи"?', 'seasonings', 'utensils,seasonings,containers,recipes', 'Seasonings - речовини, що додають смак їжі (сіль, перець, спеції)'),
(2, 'What is the English for "бронювання"?', 'reservation', 'ticket,reservation,departure,arrival', 'Reservation - попереднє бронювання місця в готелі, ресторані тощо'),
(2, 'Choose the correct translation for "itinerary"', 'маршрут подорожі', 'паспорт,маршрут подорожі,багаж,квиток', 'Itinerary - детальний план подорожі з вказанням місць і часу'),
(2, 'What does "accommodation" mean?', 'житло', 'транспорт,житло,харчування,екскурсія', 'Accommodation - місце для проживання під час подорожі'),
(2, 'What is "luggage" in Ukrainian?', 'багаж', 'документи,багаж,гроші,карта', 'Luggage - речі, які беруть із собою у подорож'),
(3, 'Choose the correct translation for "workload"', 'навантаження на роботі', 'заробітна плата,навантаження на роботі,посада,відпустка', 'Workload - обсяг роботи, який потрібно виконати'),
(3, 'Choose the correct word for "підвищення"', 'promotion', 'salary,promotion,interview,contract', 'Promotion - підвищення по службі'),
(3, 'Choose the correct word for "звільнення за скороченням штату"', 'layoff', 'resignation,layoff,termination,retirement', 'Layoff - тимчасове або постійне звільнення через економічні причини'),
(3, 'What is "probation period" in Ukrainian?', 'випробувальний термін', 'відпустка,випробувальний термін,стажування,навчальний період', 'Probation period - початковий період роботи для оцінки працівника'),
(4, 'What is the English for "свекруха"?', 'mother-in-law', 'stepmother,mother-in-law,grandmother,foster mother', 'Mother-in-law - мати чоловіка або дружини'),
(4, 'Choose the correct word for "хрещений батько"', 'godfather', 'biological father,godfather,stepfather,foster father', 'Godfather - чоловік, який бере духовну відповідальність за дитину при хрещенні'),
(4, 'What is "family bond" in Ukrainian?', 'сімейний зв''язок', 'сімейна традиція,сімейний зв''язок,сімейна таємниця,сімейна рада', 'Family bond - емоційний зв''язок між членами сім''ї');

-- Вправи для тем словникового запасу (польська мова, рівень B1–B2)
INSERT INTO VocabularyExercises (topic_id, question, correct_answer, options, explanation) VALUES
-- Podróże i transport
(17, 'Co oznacza słowo "przesiadka"?', 'пересадка (на інший транспорт)', 'пересадка (на інший транспорт),запізнення,рейс,страхування', '"Przesiadka" to zmiana środka transportu — українською "пересадка".'),
(17, 'Jak przetłumaczyć wyrażenie "odprawa biletowo-bagażowa"?', 'реєстрація квитків і багажу', 'посадка на літак,реєстрація квитків і багажу,митний контроль,повернення квитка', '"Odprawa biletowo-bagażowa" oznacza "реєстрацію квитків і багажу".'),
-- Jedzenie i gastronomia
(18, 'Jak po ukraińsku będzie "produkty pełnoziarniste"?', 'продукти з цільного зерна', 'продукти з цільного зерна,молочні продукти,заморожені продукти,готові страви', '"Produkty pełnoziarniste" to żywność z pełnego ziarna, czyli "продукти з цільного зерна".'),
(18, 'Jak po ukraińsku będzie "przetwory domowe"?', 'домашні консерви', 'домашні консерви,гарніри,солодощі,спеції', '"Przetwory domowe" to "домашні консерви" (np. dżemy, ogórki).'),
-- Praca i kariera
(19, 'Co oznacza słowo "awansować"?', 'отримати підвищення', 'отримати підвищення,звільнитися,запізнитися,взяти відпустку', '"Awansować" znaczy "отримати підвищення" у роботі.'),
(19, 'Jak przetłumaczyć słowo "umowa o pracę"?', 'трудовий договір', 'трудовий договір,резюме,співбесіда,посадова інструкція', '"Umowa o pracę" to "трудовий договір" між працівником a pracodawcą.'),
-- Relacje społeczne i emocje
(20, 'Co znaczy wyrażenie "utrzymywać kontakt"?', 'підтримувати зв’язок', 'підтримувати зв’язок,розійтися,помиритися,пожартувати', '"Utrzymywać kontakt" oznacza "підтримувати зв’язок" z kimś.'),
(20, 'Jak po ukraińsku będzie "zazdrość"?', 'заздрість', 'радість,злість,заздрість,смуток', '"Zazdrość" to uczucie — українською "заздрість".');

INSERT INTO VocabularyExercises (topic_id, question, correct_answer, options, explanation) VALUES 
-- Reisen und Transport (німецька)
(21, 'Was bedeutet "Umsteigen"?', 'пересадка (на інший транспорт)', 'відправлення,пересадка (на інший транспорт),прибуття,бронювання', '"Umsteigen" bedeutet das Wechseln des Verkehrsmittels — "пересадка".'),
(21, 'Wie übersetzt man "Fahrkarte"?', 'квиток', 'паспорт,квиток,багаж,розклад', '"Fahrkarte" ist ein Dokument für die Fahrt — "квиток".'),
-- Essen und Gastronomie (німецька)
(22, 'Was bedeutet "Vorspeise"?', 'закуска', 'основна страва,закуска,десерт,напій', '"Vorspeise" ist eine kleine Speise vor dem Hauptgericht — "закуска".'),
(22, 'Wie übersetzt man "Hauptgericht"?', 'основна страва', 'закуска,основна страва,десерт,салат', '"Hauptgericht" ist das wichtigste Gericht einer Mahlzeit — "основна страва".'),
-- Arbeit und Karriere (німецька)
(23, 'Was bedeutet "Beförderung"?', 'підвищення по службі', 'звільнення,підвищення по службі,відпустка,зарплата', '"Beförderung" bedeutet die Verbesserung der Position im Job — "підвищення".'),
(23, 'Was ist "Arbeitsvertrag"?', 'трудовий договір', 'резюме,трудовий договір,заява,рекомендація', '"Arbeitsvertrag" ist ein Vertrag zwischen Arbeitgeber und Arbeitnehmer — "трудовий договір".'),
-- Soziale Beziehungen und Emotionen (німецька)
(24, 'Was bedeutet "Freundschaft"?', 'дружба', 'кохання,дружба,повага,довіра', '"Freundschaft" ist eine enge Beziehung zwischen Freunden — "дружба".'),
(24, 'Wie übersetzt man "Eifersucht"?', 'заздрість', 'радість,злість,заздрість,смуток', '"Eifersucht" ist das Gefühl der Missgunst — "заздрість".');


-- Додаємо вправи для читання (англійська)
INSERT INTO ReadingExercises (topic_id, title, text_content, question, correct_answer, options, explanation) VALUES 
(5, 'My Daily Routine', 'I usually wake up at 7 am. Then I have breakfast and go to work. After work, I like to read books or watch TV. On weekends, I often meet friends or go for a walk in the park.', 'What time does the person wake up?', '7 am', '6 am,7 am,8 am,9 am', 'У тексті сказано: "I usually wake up at 7 am"'),
(5, 'Weather in London', 'London is known for its rainy weather. It often rains throughout the year, but summers can be quite warm. The temperature in winter rarely drops below zero.', 'What is London weather famous for?', 'Rain', 'Snow,Sun,Rain,Wind', 'У тексті сказано: "London is known for its rainy weather"'),
(6, 'Restaurant Conversation', 'Customer: Can I see the menu, please? Waiter: Of course, here you are. Customer: Thank you. I''ll have the chicken pasta. Waiter: Excellent choice. Would you like anything to drink?', 'What does the customer order?', 'Chicken pasta', 'Beef steak,Chicken pasta,Fish soup,Vegetable salad', 'Клієнт каже: "I''ll have the chicken pasta"');
-- Додаємо розширені вправи для читання (англійська)
INSERT INTO ReadingExercises (topic_id, title, text_content, question, correct_answer, options, explanation) VALUES 
(5, 
'My Daily Routine', 
'I usually wake up at 7 am and start my day with a quick shower. After that, I make a cup of coffee and prepare breakfast, usually oatmeal with fruit. Around 8 am, I leave for work, which takes me about thirty minutes by bus. My workday finishes at 5 pm, and when I get home, I like to relax by reading a book or watching a TV series. On weekends, I often spend time with friends or go hiking in the nearby forest to enjoy nature.', 
'What does the person usually do after returning home from work?', 
'Reads or watches TV', 
'Goes for a run,Eats dinner,Reads or watches TV,Cleans the house', 
'У тексті сказано: "when I get home, I like to relax by reading a book or watching a TV series"'),

(5, 
'Weather in London', 
'London is famous for its unpredictable weather. One moment you can enjoy sunshine, and the next you might need an umbrella. It rains frequently throughout the year, but winters are generally mild compared to other parts of Europe. Snow is rare, and temperatures usually stay above freezing. Summers can be surprisingly warm, with long daylight hours and pleasant evenings perfect for walks along the Thames.', 
'What makes London’s weather unpredictable according to the text?', 
'It can quickly change from sunny to rainy', 
'It never rains,It is always sunny,It can quickly change from sunny to rainy,It is very cold in winter', 
'У тексті сказано: "One moment you can enjoy sunshine, and the next you might need an umbrella"'),

(6, 
'Restaurant Conversation', 
'Customer: Good evening. Could I see the menu, please?  
Waiter: Of course, here it is.  
Customer: Thank you. Everything looks delicious. What would you recommend today?  
Waiter: Our special is the grilled salmon with lemon butter sauce.  
Customer: That sounds great. I’ll have the salmon, and could I also get a glass of white wine?  
Waiter: Certainly. Would you like sparkling or still water with that?  
Customer: Still, please.  
Later, when the meal is served, the customer compliments the waiter on the excellent taste and presentation.', 
'Which of the following best describes the customer’s attitude during the conversation?', 
'Polite and interested', 
'Rude and impatient,Indecisive,Polite and interested,Demanding and critical', 
'Із діалогу видно, що клієнт чемний, уважно слухає рекомендації офіціанта й дякує за обслуговування.');

-- Додаємо вправи для граматики (англійська)
INSERT INTO GrammarExercises (topic_id, title, explanation, question, correct_answer, options, example) VALUES 
(9, 'Present Simple', 'Present Simple використовується для регулярних дій та фактів', 'Choose the correct form: She ___ to school every day.', 'goes', 'go,goes,going,went', 'She goes to school every day. - Вона ходить до школи кожного дня.'),
(10, 'Articles', 'Артикль "the" використовується для конкретних об''єктів', 'Choose the correct article: I saw ___ beautiful bird in ___ garden.', 'a,the', 'a,a,the,the,the,a', 'I saw a beautiful bird in the garden. - Я побачив гарного птаха в саду.'),
(11, 'Modal Verbs', 'Can використовується для можливості або вміння', 'Choose the correct modal verb: She ___ speak three languages.', 'can', 'can,must,should,could', 'She can speak three languages. - Вона вміє розмовляти трьома мовами.');



