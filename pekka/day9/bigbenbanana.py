def decompress(input):
	size = 0
	while len(input) > 0:
		token_start = input.find('(')
		if(token_start >= 0):
			size = size + len(input[0:token_start])
			token_stop = input.find(')', token_start)
			token = input[token_start+1:token_stop].split('x')
			token_size = int(token[0]) 
			token_repeat = int(token[1])
			result = decompress(input[token_stop+1:token_stop+1+token_size])
			#uncomment for step 1
			#result = token_size
			size = size + (token_repeat*result)
			input = input[token_stop+1+token_size:]
		else:
			size = size + len(input.strip())
			input = ""
	return size;


with open("input", 'r') as handle:
	for file in handle:
		result = decompress(file)
		print result

