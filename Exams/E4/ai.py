# -*- coding: utf-8 -*-

# python imports
import random

# chillin imports
from chillin_client import RealtimeAI

# project imports
from ks.models import ECell, EDirection, Position
from ks.commands import ChangeDirection, ActivateWallBreaker
path = []            
p = 0
class AI(RealtimeAI):

    def __init__(self, world):
        super(AI, self).__init__(world)

    side = 1
    def initialize(self):
        print('initialize')
        if self.my_side == 'Blue':
            self.my_wall = ECell.BlueWall
            self.other_wall = ECell.YellowWall
        else:
            self.my_wall = ECell.YellowWall
            self.other_wall = ECell.BlueWall
        if(self.world.agents[self.my_side].position.x == 1):
            self.side = 1
            # self.send_command(ChangeDirection(EDirection.Right))
        else:
            self.side = 0
            # self.send_command(ChangeDirection(EDirection.Left))



    def FindPath(self, start : (int, int), target : (int, int)):
        queue = [start]
        visited = [[False for x in range(len(self.world.board[0]))] for y in range(len(self.world.board))]
        parents =  [[(-1, -1) for x in range(len(self.world.board[0]))] for y in range(len(self.world.board))]
        visited[start[1]][start[0]] = True
        #Modify Parents
        while(len(queue) > 0):
            node = queue.pop(0)
            #reach the target
            if(node[0] == target[0] and node[1] == target[1]):
                print("Path Found")
                break
            dx = [1, 0, -1, 0]
            dy = [0, 1, 0, -1]
            for i in range(len(dx)):
                neighbor = (node[0] + dx[i], node[1] + dy[i])
                if(neighbor[0] >= 0 and neighbor[0] < len(self.world.board[0]) and 
                    neighbor[1] < len(self.world.board) and neighbor[1] >= 0 and
                    not(visited[neighbor[1]][neighbor[0]]) and 
                    self.world.board[neighbor[1]][neighbor[0]] != ECell.AreaWall):
                    queue.append((neighbor[0], neighbor[1]))
                    parents[neighbor[1]][neighbor[0]] = (node[0], node[1])
                    visited[neighbor[1]][neighbor[0]] = True
        #Construct Path
        result = []
        node = target
        while(node != (-1, -1)):
            result.append(node)
            node = parents[node[1]][node[0]]
        if(len(result) > 0):
            result.pop()
        return result
    def decide(self):
        global path
        global p
        direction = self.world.agents[self.my_side].direction
        selfPos = self.world.agents[self.my_side].position
        otherPos = self.world.agents[self.other_side].position
        if(len(path) == 0 and p == 0):
            path = self.FindPath((selfPos.x, selfPos.y), (otherPos.x, otherPos.y))
            print(path)
            p += 1
        # if(len(path) == 0 and p == 0):
        #     path = self.FindPath((selfPos.x, selfPos.y), (int(len(self.world.board[0])/2 + 3), int(len(self.world.board)/2 + 2)))
        #     print(path)
        #     p += 1
        T = False
        if(len(path) == 0 and p > 0):
            print("start finding other_wall")
            for x in range(len(self.world.board[0])-2, 0, -1):
                for y in range(1, len(self.world.board)-1):
                    print('finding.....',x, y)
                    if self.world.board[y][x] == self.other_wall and (x != selfPos.x or y != selfPos.y):
                        print('other wall: ', x, y)
                        path = self.FindPath((selfPos.x, selfPos.y), (x, y))
                        print(path)
                        T = True
                        break
                if T:
                    break
        if len(path) > 0:
            (x, y) = path.pop()
            print(x, y)
            if y == selfPos.y:
                if x == selfPos.x + 1:
                    direction = EDirection.Right
                elif x == selfPos.x - 1:
                    direction = EDirection.Left
            elif x == selfPos.x:
                if y == selfPos.y + 1:
                    direction = EDirection.Down
                elif y == selfPos.y - 1:
                    direction = EDirection.Up
        # if p > 1:
        #     if(direction== EDirection.Right and self.world.board[selfPos.y][selfPos.x + 1] == ECell.AreaWall):
        #         if(self.side == 1):
        #             direction = EDirection.Down
        #         else:
        #             direction = EDirection.Up
        #     elif(direction == EDirection.Left and self.world.board[selfPos.y][selfPos.x - 1] == ECell.AreaWall):
        #         if(self.side == 1):
        #             direction = EDirection.Down
        #         else:
        #             direction = EDirection.Up
        #     elif(direction == EDirection.Up):
        #         if(self.world.board[selfPos.y][selfPos.x + 1] == ECell.AreaWall):
        #             direction = EDirection.Left
        #         elif(self.world.board[selfPos.y][selfPos.x - 1] == ECell.AreaWall):
        #             direction = EDirection.Right
        #         elif(self.side == 1 and self.world.board[selfPos.y][selfPos.x + 1] == ECell.YellowWall):
        #             direction = EDirection.Left
        #         elif (self.side == 1 and self.world.board[selfPos.y][selfPos.x - 1] == ECell.YellowWall):
        #             direction = EDirection.Right
        #         elif(self.side == 0 and self.world.board[selfPos.y][selfPos.x + 1] == ECell.BlueWall):
        #             direction = EDirection.Left
        #         elif (self.side == 0 and self.world.board[selfPos.y][selfPos.x - 1] == ECell.BlueWall):
        #             direction = EDirection.Right
        #     elif(direction == EDirection.Down):
        #         if(self.world.board[selfPos.y][selfPos.x + 1] == ECell.AreaWall):
        #             direction = EDirection.Left
        #         elif(self.world.board[selfPos.y][selfPos.x - 1] == ECell.AreaWall):
        #             direction = EDirection.Right
        #         elif(self.side == 1 and self.world.board[selfPos.y][selfPos.x + 1] == ECell.YellowWall):
        #             direction = EDirection.Left
        #         elif (self.side == 1 and self.world.board[selfPos.y][selfPos.x - 1] == ECell.YellowWall):
        #             direction =EDirection.Right
        #         elif(self.side == 0 and self.world.board[selfPos.y][selfPos.x + 1] == ECell.BlueWall):
        #             direction = EDirection.Left
        #         elif (self.side == 0 and self.world.board[selfPos.y][selfPos.x - 1] == ECell.BlueWall):
        #             direction = EDirection.Right
        
        self.send_command(ChangeDirection(direction))
        if self.world.agents[self.my_side].wall_breaker_cooldown == 0:
            self.send_command(ActivateWallBreaker())