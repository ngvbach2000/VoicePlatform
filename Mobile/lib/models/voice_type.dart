class VoiceType {
  int id;
  String name;

  VoiceType({
    required this.id,
    required this.name,
  });

  factory VoiceType.fromJson(Map<String, dynamic> json) {
    return VoiceType(
      id: json['id'],
      name: json['name'],
    );
  }
}
