#!/usr/bin/env python

class Instruction:
	def __init__(self, low, low_type, high, high_type):
		self.low = low
		self.low_type = low_type 
		self.high = high
		self.high_type = high_type 

class Bot:
	def __init__(self, id):
		self.id = id
		self.values = []
		self.instuctions = []

	def addValue(self, value):
		self.values.append(value)

	def addInstruction(self, instruction):
		self.instuctions.append(instruction)	

	def render(self):
		print self.id
		print self.values
		print self.instuctions

class Output:
	def __init__(self, id):
		self.id = id
		self.values = []

	def addValue(self, value):
		self.values.append(value)

class GameOfBots:
	def __init__(self):
		self.bots = []
		self.outputs = []

	def setup(self, input):
		with open(input, 'r') as handle:
			for setup in handle:
				split = setup.split(' ')
				if split[0] == "bot":
					low_type = 0
					high_type = 0
					if split[5] == "output":
						low_type = 1
					if split[10] == "output":
						high_type = 1

					bots = filter(lambda x: x.id==int(split[1]), self.bots)
					if bots==[]:
						bot = Bot(int(split[1]))
						bot.addInstruction(Instruction(int(split[6]), low_type, int(split[11]), high_type))
						self.bots.append(bot)
					else:
						bots[0].addInstruction(Instruction(int(split[6]), low_type, int(split[11]), high_type))
				if split[0] == "value":
					bots = filter(lambda x: x.id==int(split[5]), self.bots)
					if bots==[]:
						bot = Bot(int(split[5]))
						bot.addValue(int(split[1]))
						self.bots.append(bot)
					else:
						bots[0].addValue(int(split[1]))

	def render(self):
		for bot in self.bots:
			bot.render()

	def run(self):
		found = False
		nop = False
		while not nop:
			nop = True
			for bot in self.bots:
				if len(bot.values) == 2:
					nop = False
					low = 0
					high = 0
					if bot.values[0] > bot.values[1]:
						low = bot.values[1]
						high = bot.values[0]
					else:
						high = bot.values[1]
						low = bot.values[0]
					if(low == 17 and high == 61):
						found = True
						print "BOT:"
						print bot.id


					if bot.instuctions[0].low_type == 0 :
						lowbot = filter(lambda x: x.id==bot.instuctions[0].low, self.bots)[0]
						lowbot.addValue(low)
					else:
						outputs = filter(lambda x: x.id==bot.instuctions[0].low, self.outputs)
						if outputs == []:
							output = Output(bot.instuctions[0].low)
							output.addValue(low)
							self.outputs.append(output)
						else:
							outputs[0].addValue(low)
					if bot.instuctions[0].high_type == 0 :
						highbot = filter(lambda x: x.id==bot.instuctions[0].high, self.bots)[0]
						highbot.addValue(high)
					else:
						outputs = filter(lambda x: x.id==bot.instuctions[0].high, self.outputs)
						if outputs == []:
							output = Output(bot.instuctions[0].high)
							output.addValue(high)
							self.outputs.append(output)
						else:
							outputs[0].addValue(high)

					bot.values = []

game = GameOfBots()
game.setup("input")
game.run()
mult = 1
for output in game.outputs:
	if output.id == 0 or output.id == 1 or output.id == 2:
		mult = mult*output.values[0]
print mult