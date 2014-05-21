#include <time.h>
#include <pthread.h>
#include <semaphore.h>
#define NUMCONS 1
#define NUMPROD 1
#define BUFFERSIZE 5000

time_t inicio, fim;
pthread_t cons[NUMCONS];
pthread_t prod[NUMPROD];
pthread_mutex_t buffer_mutex;

struct buffer{
	int v[BUFFERSIZE];
	int currentidx;
};

struct buffer buf;
sem_t buffer_full;
sem_t buffer_empty;

void *consumidor(void *arg);
void *produtor(void *arg);


void *consumidor(void *arg) {
	int n;
	while (1) {
		inicio = time(NULL);
		sem_wait(&buffer_empty);
		pthread_mutex_lock(&buffer_mutex);
		n = buf.v[--buf.currentidx];
		pthread_mutex_unlock(&buffer_mutex);
		sem_post(&buffer_full);
		printf("Consumindo numero %d\n", n);
		sleep(10); // sleep por 10000 milisegundos
		fim = time(NULL);
		printf("\nThread Consumidora:  %d  \nInicio: %d (s) - Fim: %d (s)", pthread_self(), (int)inicio, (int)fim);
	}
}

void *produtor(void *arg) {
	int n = 0;
	while (1) {
		inicio = time(NULL);
		sem_wait(&buffer_full);
		pthread_mutex_lock(&buffer_mutex);
		buf.v[buf.currentidx++] = n;
		pthread_mutex_unlock(&buffer_mutex);
		sem_post(&buffer_empty);
		printf("Produzindo numero %d\n", n);
		n++;
		sleep(5); // sleep por 5000 milissegundos
		fim = time(NULL);
		printf("\nThread Produtora:  %d  \nInicio: %d (s) - Fim: %d (s)", pthread_self(), (int)inicio, (int)fim);
	}
}

int main(int argc, char **argv){
	int i;
	buf.currentidx = 0;
	pthread_mutex_init(&buffer_mutex, NULL);
	sem_init(&buffer_full, 0, BUFFERSIZE);
	sem_init(&buffer_empty, 0, 0);
	for (i = 0; i<NUMCONS; i++) {
		pthread_create(&(cons[i]), NULL, consumidor, NULL);
	}
	for (i = 0; i<NUMPROD; i++) {
		pthread_create(&(prod[i]), NULL, produtor, NULL);
	}
	fflush(stdin);
	getchar();
}
