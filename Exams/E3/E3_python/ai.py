# -*- coding: utf-8 -*-

# python imports
import random

# chillin imports
from chillin_client import RealtimeAI

# project imports
from ks.models import ECell, EDirection, Position
from ks.commands import ChangeDirection, ActivateWallBreaker


class AI(RealtimeAI):

    def __init__(self, world):
        super(AI, self).__init__(world)


    def initialize(self):
        print('initialize')
        if self.my_side == 'Blue':
            self.my_wall = ECell.BlueWall
            self.other_wall = ECell.YellowWall
        else:
            self.my_wall = ECell.YellowWall
            self.other_wall = ECell.BlueWall


    def decide(self):
        print('decide')
        if self.world.agents[self.my_side].wall_breaker_cooldown == 0:
            self.send_command(ActivateWallBreaker())

        x = self.world.agents[self.my_side].position.x
        y = self.world.agents[self.my_side].position.y
        direction = self.world.agents[self.my_side].direction
        direction_command = direction

        Uside = self.world.board[y - 1][x]
        Lside = self.world.board[y][x - 1]
        Rside = self.world.board[y][x + 1]
        Dside = self.world.board[y + 1][x]
        
        d = 0
        if self.world.agents[self.my_side].wall_breaker_cooldown != 0:
            if (Rside == self.my_wall and direction != EDirection.Left) or Rside == self.other_wall:
                direction_command = EDirection.Right
                d = 1
                print(d)
            elif (Lside == self.my_wall and direction != EDirection.Right) or Lside == self.other_wall:
                direction_command = EDirection.Left
                d = 2
                print(2)
            elif (Uside == self.my_wall and direction != EDirection.Down) or Uside == self.other_wall:
                direction_command = EDirection.Up
                d = 3
                print(3)
            elif (Dside == self.my_wall and direction != EDirection.Up) or Dside == self.other_wall:
                direction_command = EDirection.Down
                d = 4
                print(d)

        if d == 0:
            if (direction == EDirection.Right and Rside == ECell.Empty) or (direction == EDirection.Left and Lside == ECell.Empty) or (direction == EDirection.Down and Dside == ECell.Empty) or (direction == EDirection.Up and Uside == ECell.Empty) :
                direction_command = direction
            elif direction in [EDirection.Right,EDirection.Left] and Dside == ECell.Empty:
                direction_command = EDirection.Down
            elif direction in [EDirection.Right,EDirection.Left] and Uside == ECell.Empty:
                direction_command = EDirection.Up
            elif direction in [EDirection.Down,EDirection.Up] and Rside == ECell.Empty:
                direction_command = EDirection.Right 
            elif direction in [EDirection.Down,EDirection.Up] and Lside == ECell.Empty:
                direction_command = EDirection.Left
                
        self.send_command(ChangeDirection(direction_command))
        
