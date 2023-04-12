[![dotnet package](https://github.com/lvymbaa/testing/actions/workflows/unit.yml/badge.svg)](https://github.com/lvymbaa/testing/actions/workflows/unit.yml)
[![SonarCloud](https://github.com/lvymbaa/testing/actions/workflows/build.yml/badge.svg)](https://github.com/lvymbaa/testing/actions/workflows/build.yml)
# testing
MazeGame - игра, в которой игроку нужно пройти через лабиринт, забрав по пути сокровище. Количество ходов игрока (перемещений на следующую клетку лабиринта) ограничено.

## Функции приложения
### public void GameInit(GameData data)
Инициализация состояния игры.

### public bool SetMapValue(Map map, MapLocation pos, int value)
Заполнение ячейки карты значением. Возвращает True, если данные были записаны в ячейку и False, если была совершена попытка записать данные за пределы карты.

### public int GetMapValue(Map map, MapLocation pos)
Получение значения с ячейки карты. Возвращает значение ячейки карты. В случае, если была совершена попытка получить данные за пределами карты возвращает -1.

### public void MovePlayer(Direction dir, GameData data)
Передвижение маркера игрока.

### public bool ChangePlayerPosition(MapLocation targetPos, GameData data)
Перемещение в указанную позицию (попытка). Возвращает True, если перемещение было совершено и False, если переместиться в ячейку не удалось.

### public void SetExitPosition(MapLocation targetPos, GameData data)
Установка позиции выхода.

### public void SetRandomTreasurePosition(GameData data)
Установка сокровища в ячейку лабиринта.

### public void CheckTreasure(GameData data)
Проверка на сбор сокровища.

### public void CheckExit(GameData data)
Проверка на выход.

### public void GenerateMaze(GameData data)
Генерация лабиринта.

### public int CalculateShortestDistanceBetween(MapLocation start, MapLocation target)
Вычисление кратчайшего пути между точками (в ячейках).

### public void BeginSearch(MapLocation start, MapLocation goal, GameData data)
Подготовка перед началом поиска пути.

### public void Search(Node thisNode, GameData data)
Итерация поиска кратчайшего пути.

### public bool isClosed(MapLocation pos, GameData data)
Проверка, находится ли указанная ячейка в списке закрытых ячеек поиска пути. Возвращает True, если в списке закрытых есть такая ячейка и False, если такой ячейки нет.

### public bool UpdateMarker(MapLocation pos, float g, float h, float f, Node prt, GameData data)
Обновление данных ячейки из списка открытых. Возвращает True, если данные были обновлены и False, если данные не были обновлены.

### public List\<Node> GetPath(MapLocation start, MapLocation target, GameData data)
Поиск кратчайшего пути. Возвращает список вершин пути.

### public void GenerateLevel(GameData data)
Генерация уровня.

### public void SetMapSize(GameData data, int level)
Определение размера игрового поля.

### public bool WithdrawMove(GameData data)
Осуществление списаний ходов.

### public void SetRandomExitPosition(GameData data)
Размещение выхода.

### public void SetRandomBonusPosition(GameData data, int amount)
Размещение бонуса.

### public void CheckBonus(GameData data)
Проверка на нахождение игрока в позиции бонуса.

### public bool CheckGameOver(GameData data)
Проверка на завершение количества ходов игрока.


## Аттестационное тестирование

Тест 1:
Начальное состояние: игрок запустил игру
Действие: пользователь нажимает клавиши влево, вправо, вниз, вверх
Ожидаемый результат: перемещение игрока
Тест проверяет возможность перемещение игрока

Тест 2:
Начальное состояние: игрок запустил игру
Действие: пользователь нажимает клавиши влево, вправо, вниз, вверх
Ожидаемый результат: уменьшение числа ходов при перемещениях
Тест проверяет уменьшение числа ходов

Тест 3:
Начальное состояние: игрок запустил игру
Действие: пользователь перемещается в ячейку с сокровищем
Ожидаемый результат: сокровище исчезает
Тест проверяет подбор сокровища

Тест 4:
Начальное состояние: игрок запустил игру
Действие: пользователь нажимает клавиши влево, вправо, вниз, вверх при условии что там стенки
Ожидаемый результат: игрок не перемещается
Тест проверяет невозможность перемещение игрока туда, где есть стенка

Тест 5:
Начальное состояние: игрок запустил игру
Действие: пользователь нажимает клавиши влево, вправо, вниз, вверх и перемещается на ячейку выхода за отведённое число ходов
Ожидаемый результат: Сообщение о победе
Тест проверяет работу программы при прохождении игры

## Модульное тестирование

### Тест GetMapValueFilled(Позитивный):
Описание: Получение значения ячейки карты, если поле было заполнено ранее
Функция: public int GetMapValue(Map map, MapLocation pos)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 2] - значение установленной ячейки(1,2), new MapLocation(1, 2) - ссылка на поле карты(1,2)
Ожидаемый результат: Значение равно ячейке (1,2)

### Тест GetMapValueEmpty(Позитивный):
Описание: Получение значения ячейки карты, если поле не было заполнено ранее
Функция: public int GetMapValue(Map map, MapLocation pos)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 2] - значение установленной ячейки(1,2), new MapLocation(1, 1) - ссылка на поле карты(1,1)
Ожидаемый результат: Значения равно 0

### Тест GetMapValueOutsideBounds(Негативный):
Описание: Получение значения ячейки карты, если поле оказалось за пределами карты
Функция: public int GetMapValue(Map map, MapLocation pos)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 2] - значение установленной ячейки(1,2), new MapLocation(100, 100) - ссылка на поле карты(100,100)
Ожидаемый результат: Значение равно -1

### Тест SetMapValueInsideBounds(Позитивный):
Описание: Установка значения ячейки карты, если поле оказалось в пределах карты
Функция: public bool SetMapValue(Map map, MapLocation pos, int value)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 2] - значение установленной ячейки(1,2), new MapLocation(1, 2) - ссылка на поле карты(1,2)
Ожидаемый результат: Значение в ячейке (1,2) равно 2, функция вернула значение True

### Тест SetMapValueOutsideBounds(Негативный):
Описание: Установка значения ячейки карты, если поле оказалось за пределами карты
Функция: public bool SetMapValue(Map map, MapLocation pos, int value)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 2] - значение установленной ячейки(1,2), new MapLocation(100, 100) - ссылка на поле карты(100,100)
Ожидаемый результат: Функция вернула значение False

### Тест ClosedNodeExists(Позитивный):
Описание: Проверка наличия узла в списке закрытых, если узел существует
Функция: public bool isClosed(MapLocation pos, GameData data)
Входные данные: game.data.map - карта для проверки, game.data.closed - ожидаемый список закрытых узлов
Ожидаемый результат: Функция вернула значение True

### Тест ClosedNodeNotExists(Негативный):
Описание: Проверка наличия узла в списке закрытых, если узел не существует
Функция: public bool isClosed(MapLocation pos, GameData data)
Входные данные: game.data.map - карта для проверки, game.data.closed - ожидаемый список закрытых узлов
Ожидаемый результат: Функция вернула значение False


## Интеграционное тестирование

### Тест GetPathAny(Позитивный):
Описание: Получение пути до указанной ячейки карты
Функция: public List<Node> GetPath(MapLocation start, MapLocation target, GameData data)
Входные данные: game.data.map - карта для проверки, new MapLocation(0, 1) - стартовая позиция на поле карты(0,1), new MapLocation(0, 2) - целевая позиция на поле карты(0,2)
Ожидаемый результат: Возвращённый список узлов совпадает ожидаемому 

### Тест GetPathShortest(Позитивный):
Описание: Получение кратчайшего пути до указанной ячейки карты
Функция: public List<Node> GetPath(MapLocation start, MapLocation target, GameData data)
Входные данные: game.data.map - карта для проверки, new MapLocation(0, 1) - стартовая позиция на поле карты(0,1), new MapLocation(4, 1) - целевая позиция на поле карты(4,1)
Ожидаемый результат: Возвращённый список узлов совпадает ожидаемому 

### Тест CalculateShortestDistanceBetween1(Позитивный):
Описание: Получение длины кратчайшего пути между двумя ячейками карты
Функция: public int CalculateShortestDistanceBetween(MapLocation start, MapLocation target)
Входные данные: game.data.map - карта для проверки, new MapLocation(0, 0) - стартовая позиция на поле карты(0,0), new MapLocation(0, 2) - целевая позиция на поле карты(0,2)
Ожидаемый результат: Возвращённое значение равно 6

### Тест CalculateShortestDistanceBetween2(Позитивный):
Описание: Получение длины кратчайшего пути между двумя ячейками карты
Функция: public int CalculateShortestDistanceBetween(MapLocation start, MapLocation target)
Входные данные: game.data.map - карта для проверки, new MapLocation(0, 0) - стартовая позиция на поле карты(0,0), new MapLocation(4, 4) - целевая позиция на поле карты(4,4)
Ожидаемый результат: Возвращённое значение равно 16


### Тест ChangePlayerPositionToEmptyCell(Позитивный):
Описание: Смена позиции игрока при попытке перейти в пустую ячейку
Функция: public bool ChangePlayerPosition(MapLocation targetPos, GameData data)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 1] - значение установленной ячейки(1,1), game.data.playerPos - значение позиции игрока, int oldPosCell - позиция поля карты до перемещения, int newPosCell - позиция поля карты после перемещения, game.data.turnAmount - число ходов.
Ожидаемый результат: oldPosCell принимает значение CellType.empty, newPosCell принимает значение CellType.player, функция вернула значение True, game.data.turnAmount принимает значение game.data.turnAmount - 1

### Тест ChangePlayerPositionToWallCell(Негативный):
Описание: Смена позиции игрока при попытке перейти в ячейку со стеной
Функция: public bool ChangePlayerPosition(MapLocation targetPos, GameData data)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 1] - значение установленной ячейки(1,1), game.data.map.gridArray[1, 0] - значение установленной ячейки(1,0), game.data.playerPos - значение позиции игрока, int oldPosCell - позиция поля карты до перемещения, int newPosCell - позиция поля карты после перемещения, game.data.turnAmount - число ходов.
Ожидаемый результат: oldPosCell принимает значение CellType.player, newPosCell принимает значение CellType.wall, функция вернула значение False, game.data.turnAmount принимает значение game.data.turnAmount

### Тест ChangePlayerPositionFromExitCell(Позитивный):
Описание: Смена позиции игрока при попытке перейти из ячейки с выходом
Функция: public bool ChangePlayerPosition(MapLocation targetPos, GameData data)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 1] - значение установленной ячейки(1,1), game.data.map.gridArray[1, 0] - значение установленной ячейки(1,0), game.data.playerPos - значение позиции игрока, int oldPosCell - позиция поля карты до перемещения, int newPosCell - позиция поля карты после перемещения, game.data.turnAmount - число ходов.
Ожидаемый результат: oldPosCell принимает значение CellType.exit, newPosCell принимает значение CellType.player, функция вернула значение False, game.data.turnAmount принимает значение game.data.turnAmount

### Тест SearchIteration(Позитивный):
Описание: Итерация поиска пути
Функция: public void Search(Node thisNode, GameData data)
Входные данные: game.data.map - карта для проверки, game.data.map.gridArray[1, 1] - значение установленной ячейки(1,1), game.data.map.gridArray[0, 1] - значение установленной ячейки(0,1), game.data.startNode - стартовый узел пути, game.data.goalNode - конечный узел пути
Ожидаемый результат: Списки открытых и закрытых узлов совпадают с ожидаемыми
