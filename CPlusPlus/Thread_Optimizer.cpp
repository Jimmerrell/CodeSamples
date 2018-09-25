#include "Thread_Optimizer.h"
#include <ctime>
#include <Utils.h>
#include <climits>
#ifdef RBF_USE_OPENMP
  #include <omp.h>
#endif

Thread_Optimizer::Thread_Optimizer()
{
	srand(time(nullptr));
}


Thread_Optimizer::~Thread_Optimizer()
{
}

int Thread_Optimizer::GetOptimalThreadCount(int nMaxThreads, int nSeconds)
{
	std::cout << "\nGetting optimal threadCount.\n";
	std::cout << "    Test will take " << nMaxThreads * nSeconds / 60 << " minutes and " << nMaxThreads * nSeconds % 60 << " seconds.\n";
	std::cout << "    nMaxThreads = " << nMaxThreads << ".  nSeconds = " << nSeconds << ".\n";

	int optimalThreadCount = 0;
	int mostFunctionCompletions = 0;
	int functionCompletions = 0;
	double runTime = 0.0;

	for (int i = 1; i <= nMaxThreads; ++i)//test from 1 to nMaxThreads
	{
		runTime = 0.0;
		functionCompletions = 0;
#pragma omp parallel num_threads(i), shared(functionCompletions)
		while (runTime < (double)nSeconds)
		{
#pragma omp for
			for (int j = 0; j < 1000; ++j)
			{
#pragma omp atomic
				functionCompletions++;
			}
		}

		if (functionCompletions > mostFunctionCompletions)
		{
			mostFunctionCompletions = functionCompletions;
			optimalThreadCount = i;
		}
	}


	std::cout << "    Optimal ThreadCount = " << optimalThreadCount << ".\n\n";
	return optimalThreadCount;
}

int Thread_Optimizer::WorkFunction()
{

	for (int i = 0; i < 4; ++i)
	{
		m_faWorkerValues[i] = float(rand() % INT_MAX) / (float(rand() % (INT_MAX - 1)) + 0.000001);
	}

	for (int i = 0; i < 4; ++i)
	{
		m_nWorkerReturn *= m_faWorkerValues[i];
	}


	return 0;
}
