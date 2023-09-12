# -*- coding: utf-8 -*-

# python imports
import random
import collections

# chillin imports
from chillin_client import RealtimeAI

# project imports
from ks.models import ECell, EDirection, Position
from ks.commands import ChangeDirection, ActivateWallBreaker



class AI(RealtimeAI):
    DivarH=ECell.YellowWall
    DivarUS=ECell.YellowWall
    def __init__(self, world):
        super(AI, self).__init__(world)
        self.inpath=False
        self.g=(0,0)
        self.DivarH=ECell.YellowWall
        self.DivarUS=ECell.YellowWall
    

    def initialize(self):
        print('initialize')
        if(self.other_side=="Blue"):self.DivarH=ECell.BlueWall
        else:self.DivarUS=ECell.BlueWall

        

    def decide(self):
        print('decide')
        print(self.current_cycle)
        
        def bfs(grid, start, goal):

            queue = collections.deque([[start]])
            seen = set([start])
            while queue:
                path = queue.popleft()
                x1, y1 = path[-1]
                if (x1,y1)==goal:
                    return path
                for x2, y2 in ((x1+1, y1), (x1-1, y1), (x1, y1+1), (x1, y1-1)):
                    
                    if  1 <= x2 <= 33 and 1 <= y2 <= 19 and grid[y2][x2]== ECell.Empty and (x2, y2) not in seen:
                            queue.append(path + [(x2, y2)])
                            seen.add((x2, y2))

            return [s,(100,100),(100,100)]

           
        
        x= self.world.agents[self.my_side].position.x
        y= self.world.agents[self.my_side].position.y

        xe = self.world.agents[self.other_side].position.x
        ye= self.world.agents[self.other_side].position.y
	 
        Rside=self.world.board[y][x+1]
        Lside=self.world.board[y][x-1]
        Uside=self.world.board[y-1][x]
        Dside=self.world.board[y+1][x]


        Rdir=EDirection.Right
        Ldir=EDirection.Left
        Udir=EDirection.Up
        Ddir=EDirection.Down

        nowdir = self.world.agents[self.my_side].direction
        
        move_num=[(x+1,y),(x-1,y),(x,y-1),(x,y+1)]  
        move=[Rside,Lside,Uside,Dside]
        movedir=[Rdir,Ldir,Udir,Ddir]
    
        
 
        s=(x,y)

        path=bfs(self.world.board,s,(xe,ye))
        nextmove=path[1]
        nexti = move_num.index(nextmove) if (nextmove!=(100,100)) else -1


        chdir=nexti
        mohasere=False

        robero=movedir.index(nowdir)
        if(nexti==-1):
            nexti=robero
            mohasere=True

        NR=0
        NL=0
        NU=0
        ND=0
        N_Empty=[NR,NL,NU,ND]
        N_Divar=[NR,NL,NU,ND]
        N_US=[NR,NL,NU,ND]
        N_kill=[NR,NL,NU,ND]
       
        for i in range(4):
            if(robero==0 and i==1):continue
            if(robero==1 and i==0):continue
            if(robero==2 and i==3):continue
            if(robero==3 and i==2):continue
            if(move[i]==self.DivarUS):continue
            if(move[i]==ECell.AreaWall):continue
            if(i==0):
                for j in range(x+1,34):
                    if(self.world.board[y][j]==ECell.Empty):N_Empty[i]+=1
                    if(self.world.board[y][j]==self.DivarH):N_Divar[i]+=1
                    if(self.world.board[y][j]==self.DivarUS):N_US[i]+=1
                    if(self.world.board[y][j]==ECell.AreaWall):N_kill[i]+=1
 
 
            if(i==1):
                for j in range(1,x):
                    if(self.world.board[y][j]==ECell.Empty):N_Empty[i]+=1
                    if(self.world.board[y][j]==self.DivarH):N_Divar[i]+=1
                    if(self.world.board[y][j]==self.DivarUS):N_US[i]+=1
                    if(self.world.board[y][j]==ECell.AreaWall):N_kill[i]+=1
 
 
 
            if(i==2):
                for j in range(1,y):
                    if(self.world.board[j][x]==ECell.Empty):N_Empty[i]+=1
                    if(self.world.board[j][x]==self.DivarH):N_Divar[i]+=1
                    if(self.world.board[j][x]==self.DivarUS):N_US[i]+=1
                    if(self.world.board[y][j]==ECell.AreaWall):N_kill[i]+=1
 
 
            if(i==3):
                for j in range(y+1,20):
                    if(self.world.board[j][x]==ECell.Empty):N_Empty[i]+=1
                    if(self.world.board[j][x]==self.DivarH):N_Divar[i]+=1
                    if(self.world.board[j][x]==self.DivarUS):N_US[i]+=1
                    if(self.world.board[y][j]==ECell.AreaWall):N_kill[i]+=1
       


        maxE=0 #max EmptyWalls
        maxH=0 #max EmptyWalls - need to broke wall
        
        maxEi=0 #max EmptyWalls - side
        maxHi=0 #max EmptyWalls - need to broke wall-side
        # min=N_kill[0]
        # for i in range(1,4):
        #     if(min<N_kill[i]):min=N_kill[i]
        print(N_Empty)
        for i in range(0,4):
            if(N_Empty[i]==0):continue
            if(move[i]==ECell.AreaWall):continue
            if(N_Empty[i]>maxE and move[i]==ECell.Empty):
                maxE=N_Empty[i]
                maxEi=i
            if(N_Empty[i]>maxH and move[i]==self.DivarH):
                maxH=N_Empty[i]
                maxHi=i
        print(path)



        if(path[2]==(xe,ye) or path[1]==(xe,ye)):
            maxE1=0
            maxEi1=0
            maxH1=0
            maxHi1=0
            print("Yes Now")
            for i in range(0,4):
                if( move_num[i]==path[1]):continue
                if(N_Empty[i]==0):continue
                if(N_Empty[i]>maxE1 and move[i]==ECell.Empty):
                    maxE1=N_Empty[i]
                    maxEi1=i
                if(N_Empty[i]>maxH1 and move[i]==self.DivarH):
                    maxH1=N_Empty[i]
                    maxHi1=i
            if(maxE1>=maxH1 and move_num[maxEi1]!=path[1]):chdir=maxEi1
            else:
                if(N_Divar[maxHi1]<5 and N_US[maxHi1]<2  and move_num[maxHi1]!=path[1]):chdir=maxHi1
                else : chdir=maxEi1
            if(move[chdir]==ECell.AreaWall):chdir=move_num.index(path[1])

        if(mohasere==False and move[chdir]!=ECell.Empty):self.send_command(ActivateWallBreaker())
        self.send_command(ChangeDirection(movedir[chdir]))


# Bad Mohasere -----------------------------------------------------------------------------------------------

     


        if(mohasere):
            if(maxE>=maxH ):chdir=maxEi
            else:
                if(N_Divar[maxHi]<3 and N_US[i]<2 ):chdir=maxHi
                else : chdir=maxEi
       
                      
        if(mohasere and  move[chdir]!=ECell.Empty):self.send_command(ActivateWallBreaker())
        if(mohasere): self.send_command(ChangeDirection(movedir[chdir]))

        print("reached")




      