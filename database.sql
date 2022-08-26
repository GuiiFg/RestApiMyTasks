

CREATE TABLE tb_users (
	id_int SERIAL PRIMARY KEY NOT NULL,
	email_str VARCHAR(255) UNIQUE NOT NULL,
	senha_str VARCHAR(255) NOT NULL
)


CREATE TABLE tb_tasks (
	id_task_int SERIAL PRIMARY KEY NOT NULL,
	id_user_int INT,
	description_str VARCHAR(500),
	done_bool boolean,
	CONSTRAINT fk_id_user_int
      FOREIGN KEY(id_user_int) 
	  REFERENCES tb_users(id_int)
)

INSERT INTO tb_users(email_str,senha_str) VALUES ('teste@teste.com', 'teste123')

INSERT INTO tb_tasks(id_user_int, description_str, done_bool) VALUES 
(3,'Tarefa 1 de teste', FALSE),
(3,'Tarefa 2 de teste', FALSE),
(3,'Tarefa 3 de teste', TRUE),
(3,'Tarefa 4 de teste', FALSE);

SELECT * from tb_users
SELECT * from tb_tasks

SELECT * FROM tb_users WHERE email_str = 'teste@teste.com'