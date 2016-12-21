#!/usr/bin/env python

class GameOfDeath:
	def __init__(self, rows, collums):
			self.collums = x = [[None]*rows for i in range(collums)]

	def render(self):
		for x in self.collums:
			column = ""
			for y in x:
				if y:
					column = column+y
				else:
					column = column+' '

			print column

	def rect(self, collums, rows):
		for x in range(0, collums):
			for y in range(0, rows):
				self.collums[x][y] = '#'
#		game.render()

	def rotateRow(self, row, steps):
		collumns = len(self.collums)
		for x in range(0, steps):
			tmp = self.collums[collumns-1][row]
			for y in range(0, collumns-1):
				self.collums[collumns-y-1][row] = self.collums[collumns-y-2][(row)] 
			self.collums[0][row] = tmp
#		game.render()

	def rotateCollumn(self, collumn, steps):
		rows = len(self.collums[collumn])
		for x in range(0, steps):
			tmp = self.collums[collumn][rows-1]
			for y in range(0, rows-1):
				self.collums[collumn][rows-y-1] = self.collums[collumn][(rows-y-2)] 
			self.collums[collumn][0] = tmp
#		game.render()

	def run(self, input):
		with open(input, 'r') as handle:
			for action in handle:
				if action[0:4] == "rect":
					size = action[5:len(action)].split('x')
					self.rect(int(size[0]), int(size[1]))
				elif action[0:6] == "rotate":
					if action[7:10] == "row":
						size = action[11:len(action)].split(' ')
						self.rotateRow(int(size[0].split('=')[1]), int(size[2]))
					elif action[7:13] == "column":
						size = action[14:len(action)].split(' ')
						self.rotateCollumn(int(size[0].split('=')[1]), int(size[2]))

	def count(self):
		count = 0
		for x in self.collums:
			for y in x:
				if y == '#':
					count = count +1
		print count


#game = GameOfDeath(3,7)
game = GameOfDeath(6,50)
game.run("input.txt")

#game.rect(3 , 2)
#game.rotateCollumn(1, 1)
#game.rotateRow(0, 4)
#game.rotateCollumn(1, 1)
print "Done"
game.render()
game.count()